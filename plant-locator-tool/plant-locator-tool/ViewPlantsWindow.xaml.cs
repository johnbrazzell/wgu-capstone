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
        private MapWindow _window;
        public ViewPlantsWindow(MapWindow window)
        {
            InitializeComponent();
            FillGrid();
            plantListView.SelectionMode = SelectionMode.Single;
            _window = window;
        }

        private void editPlantButton_Click(object sender, RoutedEventArgs e)
        {
            if(plantListView.SelectedItem != null)
            {
                Plant selectedPlant = new Plant();
                DataRowView rowView = plantListView.SelectedItem as DataRowView;

                if(rowView != null)
                {
                    

                    selectedPlant.PlantID = Int32.Parse(rowView.Row.ItemArray[0].ToString());
                    selectedPlant.PlantName = rowView.Row.ItemArray[1].ToString();
                    selectedPlant.Street = rowView.Row.ItemArray[2].ToString();
                    selectedPlant.City = rowView.Row.ItemArray[3].ToString();
                    selectedPlant.State = rowView.Row.ItemArray[4].ToString();
                    selectedPlant.Zip = rowView.Row.ItemArray[5].ToString();
                    selectedPlant.PhoneNumber = rowView.Row.ItemArray[6].ToString();
                    selectedPlant.ProductionInformation = rowView.Row.ItemArray[7].ToString();
                    
                 


                }
                
                if(WindowOpenCheck.IsWindowOpen("EditPlantWindow"))
                {
                    return;
                }
                else
                {
                    EditPlantWindow window = new EditPlantWindow(this, selectedPlant);
                    window.Show();
                }
                
            }


        }

        private void deletePlantButton_Click(object sender, RoutedEventArgs e)
        {
            MySqlCommand deleteCommand = DBHelper.GetConnection().CreateCommand();
            deleteCommand.CommandText = "DELETE FROM plant_location WHERE plantID=@id";

            DataRowView rowView = plantListView.SelectedItem as DataRowView

            
            if (rowView != null)
            {
                string id = rowView.Row.ItemArray[0].ToString();
                int plantID = Int32.Parse(id);

                deleteCommand.Parameters.AddWithValue("@id", plantID);

                try
                {
                    deleteCommand.ExecuteNonQuery();
                    _window.RemovePinFromMap(plantID);
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

            
           
            DataTable dt = new DataTable();
            
            MySqlConnection connection = DBHelper.GetConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            
            adapter.SelectCommand = new MySqlCommand("SELECT plantID, plantName, street, city, state, zip, phoneNumber, productionInfo, createdBy, creationDate, updatedBy, updatedDate FROM plant_location", connection);
            
            adapter.Fill(dt);
            plantListView.ItemsSource = dt.DefaultView;
            plantListView.DataContext = dt;


        }
    }
}
