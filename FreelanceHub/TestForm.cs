using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;
using QuestPDF.Infrastructure;

namespace FreelanceHub
{
    public partial class TestForm : Form
    {
        private DatabaseConnection dbConnection = DatabaseConnection.Instance;
        private BdManager bdManager = new BdManager();
        private Authenticator authenticator = new Authenticator();
        private System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        private string currentProjectId;
        private string currentTaskName;
        private DateTime? startTime;

        public TestForm()
        {
            InitializeComponent();
            SetupDataGridViews();
            dbConnection.OpenConnection();
            dgvProjects.SelectionChanged += DgvProjects_SelectionChanged;
            dgvTasks.SelectionChanged += DgvTasks_SelectionChanged;
            btnStartStop.Click += BtnStartStop_Click;
            timer1.Tick += Timer1_Tick;
            timer1.Interval = 1000;

        }

        private void SetupDataGridViews()
        {
            // Настройка DataGridView для проектов
            dgvProjects.AutoGenerateColumns = false;
            dgvProjects.Columns.Clear();
            dgvProjects.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Visible = false });
            dgvProjects.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Название" });
            dgvProjects.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ClientName", HeaderText = "Клиент" });

            // Настройка DataGridView для задач
            dgvTasks.AutoGenerateColumns = false;
            dgvTasks.Columns.Clear();
            dgvTasks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Задача" });

            // Настройка DataGridView для отчетов
            dgvReports.AutoGenerateColumns = false;
            dgvReports.Columns.Clear();
            dgvReports.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProjectName", HeaderText = "Проект" });
            dgvReports.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TaskName", HeaderText = "Задача" });
            dgvReports.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Duration", HeaderText = "Длительность" });
            dgvReports.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "Цена" });
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            LoadProjects();
            UpdateTimerDisplay();
        }

        private void LoadProjects()
        {
            dgvProjects.Rows.Clear();
            string query = "SELECT Id, ProjectName AS Name, Client AS ClientName FROM ProjectInfo ORDER BY Id";
            SqlCommand command = new SqlCommand(query, dbConnection.Connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                dgvProjects.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["ClientName"].ToString());
            }
            reader.Close();
        }

        private void DgvProjects_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedRows.Count == 0) return;

            currentProjectId = dgvProjects.SelectedRows[0].Cells[0].Value?.ToString();
            if (!string.IsNullOrEmpty(currentProjectId))
            {
                LoadTasksForProject(currentProjectId);
            }
        }

        private void DgvTasks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count == 0) return;
            currentTaskName = dgvTasks.SelectedRows[0].Cells[0].Value?.ToString();
        }

        private void LoadTasksForProject(string projectId)
        {
            dgvTasks.Rows.Clear();
            string query = "SELECT TaskName FROM TaskProject WHERE ProjectId = @ProjectId ORDER BY Id";
            SqlCommand command = new SqlCommand(query, dbConnection.Connection);
            command.Parameters.AddWithValue("@ProjectId", projectId);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                dgvTasks.Rows.Add(reader["TaskName"].ToString());
            }
            reader.Close();
        }

        private void BtnStartStop_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentProjectId) || string.IsNullOrEmpty(currentTaskName))
            {
                MessageBox.Show("Выберите проект и задачу!");
                return;
            }

            if (!stopwatch.IsRunning)
            {
                // Старт таймера
                startTime = DateTime.Now;
                stopwatch.Start();
                timer1.Start();
                btnStartStop.Text = "Стоп";
            }
            else
            {
                // Стоп таймера
                stopwatch.Stop();
                timer1.Stop();
                btnStartStop.Text = "Старт";

                // Добавляем запись в отчет
                AddTimeRecord();

                stopwatch.Reset();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            UpdateTimerDisplay();
        }

        private void UpdateTimerDisplay()
        {
            lblTimer.Text = stopwatch.IsRunning
                ? stopwatch.Elapsed.ToString(@"hh\:mm\:ss")
                : "00:00:00";
        }

        private void AddTimeRecord()
        {
            if (!startTime.HasValue) return;

            TimeSpan duration = stopwatch.Elapsed;
            string projectName = dgvProjects.SelectedRows[0].Cells[1].Value.ToString();

            // Рассчитываем цену (например, 10 у.е. в час)
            decimal pricePerHour = 10;
            decimal price = Math.Round((decimal)duration.TotalHours * pricePerHour, 2);

            // Добавляем запись в DataGridView отчетов
            dgvReports.Rows.Add(
                projectName,
                currentTaskName,
                duration.ToString(@"hh\:mm\:ss"),
                price.ToString("0.00") + " у.е."
            );

            // Сохраняем в базу данных
            SaveTimeRecord(projectName, currentTaskName, startTime.Value, duration, price);

            startTime = null;
        }

        private void SaveTimeRecord(string projectName, string taskName, DateTime startTime, TimeSpan duration, decimal price)
        {
            string query = @"INSERT INTO TimeRecords (ProjectName, TaskName, StartTime, Duration, Price) 
                             VALUES (@ProjectName, @TaskName, @StartTime, @Duration, @Price)";

            SqlCommand command = new SqlCommand(query, dbConnection.Connection);
            command.Parameters.AddWithValue("@ProjectName", projectName);
            command.Parameters.AddWithValue("@TaskName", taskName);
            command.Parameters.AddWithValue("@StartTime", startTime);
            command.Parameters.AddWithValue("@Duration", duration);
            command.Parameters.AddWithValue("@Price", price);

            command.ExecuteNonQuery();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvReports.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта!");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "Сохранить отчет как PDF",
                FileName = $"Отчет_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToPDF(dgvReports, saveFileDialog.FileName);
                MessageBox.Show("Отчет успешно экспортирован в PDF!");
            }
        }
        private void ExportToPDF(DataGridView dataGridView, string filePath)
        {
            Document document = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);

            try
            {
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Добавляем заголовок
                Paragraph title = new Paragraph("Отчет по задачам",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK));
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                // Добавляем дату создания
                document.Add(new Paragraph($"Дата создания: {DateTime.Now.ToString("dd.MM.yyyy HH:mm")}"));
                document.Add(Chunk.NEWLINE); // Пустая строка

                // Создаем таблицу в PDF
                PdfPTable pdfTable = new PdfPTable(dataGridView.Columns.Count);
                pdfTable.WidthPercentage = 100;
                pdfTable.SpacingBefore = 10f;
                pdfTable.SpacingAfter = 10f;

                // Устанавливаем ширину столбцов (равномерно)
                float[] columnWidths = new float[dataGridView.Columns.Count];
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    columnWidths[i] = 100f / dataGridView.Columns.Count;
                }
                pdfTable.SetWidths(columnWidths);

                // Добавляем заголовки столбцов
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText,
                        FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK)));
                    cell.BackgroundColor = new BaseColor(220, 220, 220);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Padding = 5;
                    pdfTable.AddCell(cell);
                }

                // Добавляем данные
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    // Пропускаем пустые строки
                    if (dataGridView.Rows[i].IsNewRow) continue;

                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        string cellValue = dataGridView.Rows[i].Cells[j].Value?.ToString() ?? string.Empty;
                        PdfPCell cell = new PdfPCell(new Phrase(cellValue,
                            FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK)));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.Padding = 5;
                        pdfTable.AddCell(cell);
                    }
                }

                document.Add(pdfTable);


                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте в PDF: {ex.Message}");
            }
            finally
            {
                document.Close();
            }
        }
    }
}