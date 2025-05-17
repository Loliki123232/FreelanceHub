using System.Data.Common;
using System.Text.RegularExpressions;

namespace FreelanceHub
{
    public partial class Form1 : Form
    {
        DatabaseConnection dbConnection = DatabaseConnection.Instance;
        BdManager bdManager = new BdManager();
        Authenticator authenticator = new Authenticator();
        private string selectedEmail;
        private string selectedPassword;
        public Form1()
        {
            InitializeComponent();
            dbConnection.OpenConnection();
        }
        private bool IsValidEmail(string email)
        {

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private void btnSing_up_Click(object sender, EventArgs e)
        {
            selectedEmail = texttBoxEmail.Text;
            selectedPassword = texttBoxPassword.Text;
            if (string.IsNullOrEmpty(selectedEmail) || string.IsNullOrEmpty(selectedPassword))
            {
                MessageBox.Show("����������, ������� email � password.");
                return;
            }
            if (!IsValidEmail(texttBoxEmail.Text))
            {
                MessageBox.Show("����������, ������� ���������� email.");
                return;
            }
            if (selectedEmail.Equals(selectedPassword, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("������ �� ������ ��������� � email.");
                return;
            }
                bdManager.SaveSelectedValueFreelanceToDatabase(selectedEmail, selectedPassword);
                MessageBox.Show("����������� ������ �������");

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                texttBoxPassword.PasswordChar = '\0';
            }
            else
            {
                texttBoxPassword.PasswordChar = '�';
            }
        }

        private void btnSign_in_Click(object sender, EventArgs e)
        {
            selectedEmail = texttBoxEmail.Text;
            selectedPassword = texttBoxPassword.Text;
            if (string.IsNullOrEmpty(selectedEmail) || string.IsNullOrEmpty(selectedPassword))
            {
                MessageBox.Show("����������, ������� email � password.");
                return;
            }
            if (!IsValidEmail(texttBoxEmail.Text))
            {
                MessageBox.Show("����������, ������� ���������� email.");
                return;
            }
            if (selectedEmail.Equals(selectedPassword, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("������ �� ������ ��������� � email.");
                return;
            }
            if (authenticator.AreCredentialsValidFreelance(selectedEmail, selectedPassword))
                {
                    MessageBox.Show("�������� ����.");
                    TestForm testForm = new TestForm();
                    testForm.ShowDialog();
                    dbConnection.CloseConnection();
                }
                else
                {
                    MessageBox.Show("�������� email ��� ������.");
                    return;
                }
            }
     }
}
    


