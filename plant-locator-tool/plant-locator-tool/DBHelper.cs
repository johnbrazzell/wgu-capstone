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



        public static void SetAdminStatus(bool isAdmin)
        {
            _isAdmin = isAdmin;
           
        }

        public static bool GetAdminStatus()
        {
            return _isAdmin;
        }

        public static MySqlConnection GetConnection()
        {
            return _connection;
        }

        public static string GetCurrentUser()
        {
            return _currentUser;
        }

        static public void OpenConnection()
        {
       
            MySqlConnectionStringBuilder connectionString = new MySqlConnectionStringBuilder();
            connectionString.Server = "127.0.0.1";
            /*
             * CHANGE USERID AND PASSWORD BEFORE EVALUATING
             * SET TO YOUR LOCAL MYSQL WORKBENCH ID AND PASSWORD
             */
            connectionString.UserID = "root";
            connectionString.Password = "#90BakeFree36";
            /*
             * 
             */
            connectionString.Port = 3306;
            connectionString.Database = "plant_locator_db";
            connectionString.AllowUserVariables = true;

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





        static public bool VerifyLogin(string userName, string password)
        {


            MySqlCommand loginCheckCommand = _connection.CreateCommand();
            loginCheckCommand.CommandText = "SELECT * FROM user WHERE username=@username AND password=@password";
            loginCheckCommand.Parameters.AddWithValue("@username", userName);
            loginCheckCommand.Parameters.AddWithValue("@password", password);

            MySqlDataReader loginReader = loginCheckCommand.ExecuteReader();


       
            if (loginReader.HasRows)
            {
                while(loginReader.Read())
                {
                    //Store admin status and username
                    string adminStatus = loginReader["isAdmin"].ToString();
                    _currentUser = loginReader["username"].ToString();
                    if(adminStatus == "0")
                    {
                        SetAdminStatus(false);
                    }
                    else
                    {
                        SetAdminStatus(true);
                    }
                    break;
                }
               
                
                loginReader.Close();
                CreateLoginTimestamp(userName);
                return true;

            }
            else
            {
                loginReader.Close();
                return false;
           
            }

            
            
        }



        private static void CreateLoginTimestamp(string username)
        {
            MySqlCommand command = _connection.CreateCommand();
            command.CommandText = "UPDATE user SET lastLogin=@newLoginTime WHERE username=@username";
            command.Parameters.AddWithValue("@newLoginTime", DateTime.Now);
            command.Parameters.AddWithValue("@username", username);
            command.ExecuteNonQuery();
        }


        public static void AddNewUser(string userName, string password, bool isAdmin)
        {
            MySqlCommand addUserCommand = _connection.CreateCommand();
            addUserCommand.CommandText = "INSERT INTO user (username, password, isAdmin)" +
                "VALUES(@username, @password, @isAdmin)";

            addUserCommand.Parameters.AddWithValue("@username", userName);
            addUserCommand.Parameters.AddWithValue("@password", password);
            addUserCommand.Parameters.AddWithValue("@isAdmin", isAdmin);

            addUserCommand.ExecuteNonQuery();
        }

    }
}
