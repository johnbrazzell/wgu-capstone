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

namespace plant_locator_tool
{
    /// <summary>
    /// Interaction logic for AddUsersWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(usernameTextBox.Text))
            {
                MessageBox.Show("Username cannot be left blank");
                return;
            }
            else if(String.IsNullOrWhiteSpace(passwordBox.Password))
            {
                MessageBox.Show("Password cannot be left blank");
                return;
            }

            DBHelper.AddNewUser(usernameTextBox.Text, passwordBox.Password, isAdminCheckbox.IsChecked.Value);
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
