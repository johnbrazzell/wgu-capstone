using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace plant_locator_tool
{

    /// <summary>
    /// Add connection string info here
    /// </summary>
    public static class DBHelper
    {

        private static MySqlConnection _connection;
        private static string _currentUser;
        private static bool _isAdmin;

        public static void Login(string userName, string password)
        {

        }

        public static MySqlConnection GetConnection()
        {
            return _connection;
        }

        static public void OpenConnection()
        {
            //TODO Add connection string information
            MySqlConnectionStringBuilder connectionString = new MySqlConnectionStringBuilder();
            connectionString.Server = "127.0.0.1";
            connectionString.UserID = "root";
            connectionString.Port = 3306;
            connectionString.Database = "plant_locator_db";
            connectionString.Password = "#90BakeFree36";

            _connection = new MySqlConnection(connectionString.ToString());

            if (_connection.State.ToString() == "Open")
            {
                return;
            }
            else
            {
                try
                {
                    _connection.Open();
                    //System.Windows.MessageBox.Show(_connection.State.ToString());
                }
                catch(MySqlException e)
                {
                    System.Windows.MessageBox.Show(e.Message, "Error occured when trying to open DB connection.");
                }
            }
        }

        static public void CloseConnection()
        {
            if (_connection.State.ToString() == "Closed")
            {
                return;
            }
            else
            {
                try
                {
                    if(_connection.State.ToString() == "Open")
                    {
                        _connection.Close();
                    }
                }
                catch(MySqlException e)
                {
                    System.Windows.MessageBox.Show(e.Message, "Error occured when trying to close DB connection");
                }
            }
        }


        static public void ExecuteQuery(string query)
        {
            MySqlCommand command = _connection.CreateCommand();
            command.CommandText = query;
            MySqlDataReader reader = command.ExecuteReader();
        }


        static public bool VerifyLogin(string userName, string password)
        {
            MySqlCommand loginCheckCommand = _connection.CreateCommand();
            loginCheckCommand.CommandText = "SELECT * FROM user WHERE username=@username AND password=@password";
            loginCheckCommand.Parameters.AddWithValue("@username", userName);
            loginCheckCommand.Parameters.AddWithValue("@password", password);

            MySqlDataReader loginReader = loginCheckCommand.ExecuteReader();


            //while(loginReader.Read())
            //{
            if (loginReader.HasRows)
            {
                loginReader.Close();
                return true;

            }
            else
            {
                loginReader.Close();
                return false;
           
            }
            
        }




        public static void AddLocation()
        {

        }


        public static void DeleteLocation()
        {

        }

        public static void AddNewUser()
        {

        }


        public static void DeleteUser()
        {

        }


        public static void UpdatePassword()
        {

        }

        public static void GetUserList()
        {

        }
    }
}
