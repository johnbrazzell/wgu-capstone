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
       
        }

        public void FillGrid()
        {
            DataTable dt = new DataTable();
            MySqlConnection connection = DBHelper.GetConnection();
            MySqlDataAdapter adapater = new MySqlDataAdapter();
            adapater.SelectCommand = new MySqlCommand("SELECT userID, username, isAdmin, lastLogin FROM plant_locator_db.user", connection);
            adapater.Fill(dt);
            userListView.ItemsSource = dt.DefaultView;
            userListView.DataContext = dt;

        }

        private void editUserButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteUserButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
