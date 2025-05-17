using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace FreelanceHub
{
    public class DatabaseConnection
    {
        private static DatabaseConnection _instance;
        private static readonly object _lock = new object();
        private SqlConnection _connection;


        private DatabaseConnection()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Кирилл\\source\\repos\\FreelanceHub1\\FreelanceHub\\Database1.mdf;Integrated Security=True"; // Замените на вашу строку подключения
            _connection = new SqlConnection(connectionString);
        }

        public static DatabaseConnection Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DatabaseConnection();
                    }
                    return _instance;
                }
            }
        }

        public SqlConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        public void OpenConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
    public class BdManager
    {
        DatabaseConnection dbConnection = DatabaseConnection.Instance;

        public void SaveSelectedValueFreelanceToDatabase(string email, string password)
        {
            email = email.Trim();
            password = password.Trim();

            using (SqlCommand command = new SqlCommand("INSERT INTO LoginFrilance(Email, Password) VALUES (@Email, @Password)", dbConnection.Connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);
                command.ExecuteNonQuery();
            }
            
        }
    }
    public class Authenticator
    {
        DatabaseConnection dbConnection = DatabaseConnection.Instance;
        public bool AreCredentialsValidFreelance(string email, string password)
        {
            email = email.Trim();
            password = password.Trim();
            string query = "SELECT COUNT(*) FROM LoginFrilance WHERE Email = @Email AND Password = @Password";

            using (SqlCommand command = new SqlCommand(query, dbConnection.Connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                int count = (int)command.ExecuteScalar();
                return count > 0;
            }

        }
    }
}
