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
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {

            if(String.IsNullOrWhiteSpace(passwordTextBox.Password))
            {
                MessageBox.Show("Password cannot be left blank");
                return;
            }
            

            MySqlCommand command = DBHelper.GetConnection().CreateCommand();
            command.CommandText = "UPDATE user SET password=@password WHERE username=@username";
            command.Parameters.AddWithValue("@password", passwordTextBox.Password);
            command.Parameters.AddWithValue("@username", DBHelper.GetCurrentUser());
            
            try
            {

                command.ExecuteNonQuery();
            }
            catch (MySqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }

            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
