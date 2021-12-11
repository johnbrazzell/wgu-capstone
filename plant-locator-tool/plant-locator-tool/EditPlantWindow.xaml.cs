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
    /// Interaction logic for EditPlantWindow.xaml
    /// </summary>
    public partial class EditPlantWindow : Window
    {
        ViewPlantsWindow _window;
        Plant _plant;
        public EditPlantWindow(ViewPlantsWindow window, Plant plant)
        {
            InitializeComponent();
   
            _window = window;
            _plant = plant;

         
            plantNameTextbox.Text = plant.PlantName;
            phoneNumberTextbox.Text = plant.PhoneNumber;
            productsProducedTextbox.Text = plant.ProductionInformation;
            streetTextbox.Text = plant.Street;
            cityTextbox.Text = plant.City;
            stateTextbox.Text = plant.State;
            zipTextBox.Text = plant.Zip;

            //if the address changes need to query bing maps again to get new lat/long
        }

        private void updatePlantbutton_Click(object sender, RoutedEventArgs e)
        {

            MySqlCommand command = DBHelper.GetConnection().CreateCommand();
            command.CommandText = "UPDATE plant_location SET plantName=@plantName, phoneNumber=@phoneNumber," +
                "productionInfo=@productionInfo, street=@street, city=@city, state=@state, zip=@zip," +
                "updatedBy=@updatedBy, updatedDate=@updatedDate WHERE plantID=@plantID";
            command.Parameters.AddWithValue("@plantName", plantNameTextbox.Text);
            command.Parameters.AddWithValue("@phoneNumber", phoneNumberTextbox.Text);
            command.Parameters.AddWithValue("@productionInfo", productsProducedTextbox.Text);
            command.Parameters.AddWithValue("@street", streetTextbox.Text);
            command.Parameters.AddWithValue("@city", cityTextbox.Text);
            command.Parameters.AddWithValue("@state", stateTextbox.Text);
            command.Parameters.AddWithValue("@zip", zipTextBox.Text);
            command.Parameters.AddWithValue("@updatedBy", DBHelper.GetCurrentUser());
            command.Parameters.AddWithValue("@updatedDate", DateTime.Now);
            command.Parameters.AddWithValue("@plantID", _plant.PlantID);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (MySqlException exception)
            {
                MessageBox.Show(exception.ToString());
                return;
            }


            _window.FillGrid();

            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
