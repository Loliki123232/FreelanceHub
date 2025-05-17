namespace FreelanceHub
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dgvProjects = new DataGridView();
            dgvTasks = new DataGridView();
            dgvReports = new DataGridView();
            btnStartStop = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            lblTimer = new Label();
            btnExport = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProjects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
            SuspendLayout();
            // 
            // dgvProjects
            // 
            dgvProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProjects.Location = new Point(0, 88);
            dgvProjects.Name = "dgvProjects";
            dgvProjects.RowHeadersWidth = 51;
            dgvProjects.Size = new Size(486, 623);
            dgvProjects.TabIndex = 0;
            // 
            // dgvTasks
            // 
            dgvTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTasks.Location = new Point(492, 88);
            dgvTasks.Name = "dgvTasks";
            dgvTasks.RowHeadersWidth = 51;
            dgvTasks.Size = new Size(543, 623);
            dgvTasks.TabIndex = 0;
            // 
            // dgvReports
            // 
            dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReports.Location = new Point(1041, 88);
            dgvReports.Name = "dgvReports";
            dgvReports.RowHeadersWidth = 51;
            dgvReports.Size = new Size(536, 623);
            dgvReports.TabIndex = 0;
            // 
            // btnStartStop
            // 
            btnStartStop.Location = new Point(178, 27);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new Size(94, 29);
            btnStartStop.TabIndex = 1;
            btnStartStop.Text = "Старт";
            btnStartStop.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Location = new Point(32, 31);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(50, 20);
            lblTimer.TabIndex = 2;
            lblTimer.Text = "label1";
            // 
            // btnExport
            // 
            btnExport.Location = new Point(1322, 27);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(94, 29);
            btnExport.TabIndex = 3;
            btnExport.Text = "Экспорт";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1590, 752);
            Controls.Add(btnExport);
            Controls.Add(lblTimer);
            Controls.Add(btnStartStop);
            Controls.Add(dgvReports);
            Controls.Add(dgvTasks);
            Controls.Add(dgvProjects);
            Name = "TestForm";
            Text = "TestForm";
            Load += TestForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProjects).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProjects;
        private DataGridView dgvTasks;
        private DataGridView dgvReports;
        private Button btnStartStop;
        private System.Windows.Forms.Timer timer1;
        private Label lblTimer;
        private Button btnExport;
    }
}