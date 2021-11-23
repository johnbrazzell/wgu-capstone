using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace plant_locator_tool
{
    class UserViewModel
    {
        public DataView UserData
        {
            get
            {
                DataTable dt = new DataTable();
                MySqlConnection connection = DBHelper.GetConnection();
                MySqlDataAdapter adapater = new MySqlDataAdapter();
                adapater.SelectCommand = new MySqlCommand("SELECT userID, username, isAdmin, lastLogin FROM plant_locator_db.user", connection);
                adapater.Fill(dt);
                return dt.DefaultView;
            }
        }
    }
}
