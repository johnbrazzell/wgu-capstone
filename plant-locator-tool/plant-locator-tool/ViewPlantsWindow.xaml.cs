using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ViewPlantsWindow.xaml
    /// </summary>
    public partial class ViewPlantsWindow : Window
    {
        public ViewPlantsWindow()
        {
            InitializeComponent();
            FillGrid();
            plantListView.SelectionMode = SelectionMode.Single;
        }

        private void editPlantButton_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void deletePlantButton_Click(object sender, RoutedEventArgs e)
        {
            MySqlCommand deleteCommand = DBHelper.GetConnection().CreateCommand();
            deleteCommand.CommandText = "DELETE FROM plant_location WHERE plantID=@id";

            DataRowView rowView = plantListView.SelectedItem as DataRowView;
            if (rowView != null)
            {
                string id = rowView.Row.ItemArray[0].ToString();
                int plantID = Int32.Parse(id);

                deleteCommand.Parameters.AddWithValue("@id", plantID);

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

        public void FillGrid()
        {
           
            DataTable dataTable = new DataTable();
            
            MySqlConnection connection = DBHelper.GetConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            
            adapter.SelectCommand = new MySqlCommand("SELECT plantID, plantName, plantAddress, phoneNumber, updatedBy, updatedDate FROM plant_location", connection);
            adapter.Fill(dataTable);
            plantListView.ItemsSource = dataTable.DefaultView;
            plantListView.DataContext = dataTable;


        }
    }
}
