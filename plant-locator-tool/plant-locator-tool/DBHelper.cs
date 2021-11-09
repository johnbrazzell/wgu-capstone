﻿using System;
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
            connectionString.Server = "";
            connectionString.UserID = "";
            connectionString.Port = 0;
            connectionString.Database = "";
            connectionString.Password = "";

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


        static public void ExecuteQuery(string query)
        {
            MySqlCommand command = _connection.CreateCommand();
            command.CommandText = query;
            MySqlDataReader reader = command.ExecuteReader();
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