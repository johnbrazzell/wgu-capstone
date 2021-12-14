using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using MySql.Data.MySqlClient;

namespace plant_locator_tool
{
    /// <summary>
    /// Interaction logic for ViewUsersWindow.xaml
    /// </summary>
    public partial class ViewUsersWindow : Window
    {


        public ViewUsersWindow()
        {
            InitializeComponent();
            FillGrid();
            userListView.SelectionMode = SelectionMode.Single;
            
        }

        public void FillGrid()
        {
            DataTable dt = new DataTable();
            
            MySqlConnection connection = DBHelper.GetConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand("SELECT userID, username, isAdmin, lastLogin FROM plant_locator_db.user", connection);
            adapter.Fill(dt);
            userListView.ItemsSource = dt.DefaultView;
            userListView.DataContext = dt;
           
            
            
        }

        private void editUserButton_Click(object sender, RoutedEventArgs e)
        {
            // load another window showing which user you are editing
            // allow user to edit admin status and save that back into database
            // refresh database on screen
            if(userListView.SelectedItem != null)
            {
                User selectedUser = new User();
                DataRowView rowView = userListView.SelectedItem as DataRowView;
                if(rowView != null)
                {
                  
                    selectedUser.UserID = Int32.Parse(rowView.Row.ItemArray[0].ToString());
                    selectedUser.UserName = rowView.Row.ItemArray[1].ToString();
                    int adminStatus = Int32.Parse(rowView.Row.ItemArray[2].ToString());
                    if(adminStatus == 0)
                    {
                        selectedUser.AdminStatus = false;
                    }
                    else
                    {
                        selectedUser.AdminStatus = true;
                    }

                    //selectedUser.LastLogin = DateTime.Parse(rowView.Row.ItemArray[3].ToString());
                }

                //open edit user window
                EditUserWindow editUser = new EditUserWindow(this, selectedUser);
                editUser.Show();
            }
        }

        private void deleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            MySqlCommand deleteCommand = DBHelper.GetConnection().CreateCommand();
            deleteCommand.CommandText = "DELETE FROM user WHERE username=@username";

            DataRowView rowView = userListView.SelectedItem as DataRowView;
            if(rowView != null)
            {
                string username = rowView.Row.ItemArray[1].ToString();
                deleteCommand.Parameters.AddWithValue("@username", username);

                try 
                { 
                    deleteCommand.ExecuteNonQuery();
                }
                catch (MySqlException exception)
                {
                    MessageBox.Show(exception.ToString());
                }

            }


            //Update the grid
            FillGrid();

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
