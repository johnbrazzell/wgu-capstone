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
using BingMapsRESTToolkit;
using Microsoft.Maps.MapControl.WPF;

namespace plant_locator_tool
{
    /// <summary>
    /// Interaction logic for EditPlantWindow.xaml
    /// </summary>
    /// 
    public partial class EditPlantWindow : Window
    {
        ViewPlantsWindow _window;
        Plant _plant;

        private string _initialAddress;
        private double _latitude;
        private double _longitude;

        //string 
        public EditPlantWindow(ViewPlantsWindow window, Plant plant)
        {
            InitializeComponent();
   
            _window = window;
            _plant = plant;

            _initialAddress = $"{streetTextbox.Text} {cityTextbox.Text} {stateTextbox.Text} {zipTextBox.Text}";

            plantNameTextbox.Text = plant.PlantName;
            phoneNumberTextbox.Text = plant.PhoneNumber;
            productsProducedTextbox.Text = plant.ProductionInformation;
            streetTextbox.Text = plant.Street;
            cityTextbox.Text = plant.City;
            stateTextbox.Text = plant.State;
            zipTextBox.Text = plant.Zip;

            //if the address changes need to query bing maps again to get new lat/long

            //check if address field is different
            //if different geocode the address and update the lat/long
            //if not different just update the other fields?
        }

        private void updatePlantbutton_Click(object sender, RoutedEventArgs e)
        {
            if(HasAddressChanged())
            {
                GeocodeAddress();
                UpdateWithAddressChanged();
                UpdatePushPin();
            }
            else
            {
                UpdateWithoutAddressChanged();
            }
            
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
        private void UpdateWithoutAddressChanged()
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

        
        private bool HasAddressChanged()
        {
            string updatedAddress = $"{streetTextbox.Text} {cityTextbox.Text} {stateTextbox.Text} {zipTextBox.Text}";

            if(_initialAddress.Equals(updatedAddress))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void UpdateWithAddressChanged()
        {

            MySqlCommand command = DBHelper.GetConnection().CreateCommand();
            command.CommandText = "UPDATE plant_location SET plantName=@plantName, phoneNumber=@phoneNumber," +
                "productionInfo=@productionInfo, street=@street, city=@city, state=@state, zip=@zip," +
                "updatedBy=@updatedBy, updatedDate=@updatedDate, lattitude=@latitude, longitude=@longitude WHERE plantID=@plantID";
            command.Parameters.AddWithValue("@plantName", plantNameTextbox.Text);
            command.Parameters.AddWithValue("@phoneNumber", phoneNumberTextbox.Text);
            command.Parameters.AddWithValue("@productionInfo", productsProducedTextbox.Text);
            command.Parameters.AddWithValue("@street", streetTextbox.Text);
            command.Parameters.AddWithValue("@city", cityTextbox.Text);
            command.Parameters.AddWithValue("@state", stateTextbox.Text);
            command.Parameters.AddWithValue("@zip", zipTextBox.Text);
            command.Parameters.AddWithValue("@updatedBy", DBHelper.GetCurrentUser());
            command.Parameters.AddWithValue("@updatedDate", DateTime.Now);
            command.Parameters.AddWithValue("@latitude", _latitude);
            command.Parameters.AddWithValue("@longitude", _longitude);
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


        public async void GeocodeAddress()
        {


            var request = new GeocodeRequest()
            {


                Query = $"{streetTextbox.Text} {cityTextbox.Text} {stateTextbox.Text} {zipTextBox.Text}",
                IncludeIso2 = true,
                IncludeNeighborhood = true,
                MaxResults = 1,
                BingMapsKey = "AkbVNqEV1maGXyLUBXjt4QnK1H6LgGdg3UmVxVPEjPbVFtp_a6uqmp7WF-pQQ6n_"

            };

            var response = await request.Execute();

            if (response != null &&
                response.ResourceSets != null &&
                response.ResourceSets.Length > 0 &&
                response.ResourceSets[0].Resources != null &&
                response.ResourceSets[0].Resources.Length > 0)
            {
                var result = response.ResourceSets[0].Resources[0] as BingMapsRESTToolkit.Location;

                _latitude = result.Point.Coordinates[0];
                _longitude = result.Point.Coordinates[1];

               
            }

      
        }

        private void UpdatePushPin()
        {
            MapWindow mapWindow = Application.Current.MainWindow as MapWindow;
            mapWindow.RemovePinFromMap(_plant.PlantID);
            mapWindow.AddPinToMap(_plant.PlantID, _latitude, _longitude);
           
        }

    }
}
