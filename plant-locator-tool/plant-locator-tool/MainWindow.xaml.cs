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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace plant_locator_tool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            //Need to check if credentials are correct in DB and then 
            //move to the next screen
            DBHelper.OpenConnection();
            
            bool loginWasVerified = DBHelper.VerifyLogin(userNameTextBox.Text, passwordBox.Password);
            

            

            if (loginWasVerified)
            {
                MapWindow mapWindow = new MapWindow();
                this.Close();
                App.Current.MainWindow = mapWindow;
                mapWindow.Show();
            }
            else
            {
                MessageBox.Show("Username and password invalid");
            }

        }
    }
}
