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
using MySql.Data.MySqlClient;

namespace plant_locator_tool
{
    /// <summary>
    /// Interaction logic for EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        private User updatedUser;
        private ViewUsersWindow parentWindow;
  
        private string oldUsername;
        public EditUserWindow(ViewUsersWindow window, User user)
        {
            InitializeComponent();
            parentWindow = window;
            if(user.AdminStatus)
            {
              isAdminCheckBox.IsChecked = true;
            }
            nameOfUserLabel.Content = "Editing User " + user.UserName;

    
      
            //Store username for DB update
            oldUsername = user.UserName;
            
            updatedUser = user;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(usernameTextBox.Text))
            {
                MessageBox.Show("Username cannot be left blank");
                return;
                //updatedUser.UserName = oldUsername;
            }
            else
            {

                updatedUser.UserName = usernameTextBox.Text;
                updatedUser.AdminStatus = isAdminCheckBox.IsChecked.Value;
            
            }

            MySqlCommand command = DBHelper.GetConnection().CreateCommand();
          

            command.CommandText = "UPDATE user SET username=@username, isAdmin=@isAdmin WHERE username=@oldUsername";
            command.Parameters.AddWithValue("@username", updatedUser.UserName);
            command.Parameters.AddWithValue("@isAdmin", updatedUser.AdminStatus);
            command.Parameters.AddWithValue("oldUsername", oldUsername);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (MySqlException exception)
            {
                MessageBox.Show(exception.ToString());
                return; 
            }
            parentWindow.FillGrid();

            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


  
    }
}
