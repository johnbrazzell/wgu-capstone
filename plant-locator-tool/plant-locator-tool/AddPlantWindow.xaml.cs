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
using BingMapsRESTToolkit;
using MySql.Data.MySqlClient;
using Microsoft.Maps.MapControl.WPF;
using System.Diagnostics;

namespace plant_locator_tool
{
    /// <summary>
    /// Interaction logic for AddPlantWindow.xaml
    /// </summary>
    /// 
    public partial class AddPlantWindow : Window
    {
        string _sessionKey;
        MapWindow _mapWindow;
        Pushpin _pin;
        int _lastID;
        
        public AddPlantWindow(MapWindow mapWindow)
        {
            InitializeComponent();

            _pin = new Pushpin();
            _mapWindow = mapWindow;

            mapWindow.mainMap.CredentialsProvider.GetCredentials((c) =>
            {
                _sessionKey = c.ApplicationId;
            });
            
        }

        private void addPlantButton_Click(object sender, RoutedEventArgs e)
        {
            if(IsFormValidated())
            {
                GeocodeAddress();
            }
        }



        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
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
                BingMapsKey = _sessionKey

            };

            var response = await request.Execute();

            if (response != null &&
                response.ResourceSets != null &&
                response.ResourceSets.Length > 0 &&
                response.ResourceSets[0].Resources != null &&
                response.ResourceSets[0].Resources.Length > 0)
            {
                var result = response.ResourceSets[0].Resources[0] as BingMapsRESTToolkit.Location;





                double latitude = result.Point.Coordinates[0];
                double longitude = result.Point.Coordinates[1];




                Microsoft.Maps.MapControl.WPF.Location newLocation = new Microsoft.Maps.MapControl.WPF.Location(latitude, longitude);

                AddPlantToDatabase(latitude, longitude);

                _mapWindow.AddPinToMap(_lastID, latitude, longitude);

                /*
                 * CheckCoordinates is a test method
                 * Uncomment to run test when adding plant
                 */
                //CheckCoordinates(latitude, longitude);

                this.Close();





            }
            else
            {
                MessageBox.Show("Address not found");
            }
        }


        private void AddPlantToDatabase(double lattitude, double longitude)
        {
            MySqlCommand addPlantCommand = DBHelper.GetConnection().CreateCommand();
            addPlantCommand.CommandText = "INSERT INTO plant_location (plantName, street, city, state, zip, phoneNumber, " +
                "productionInfo, createdBy, creationDate, updatedBy, updatedDate, lattitude, longitude) " +
                "VALUES(@plantName, @street, @city, @state, @zip, @phoneNumber, @productionInfo, @creationUsername," +
                "@creationDate, @updatedUsername, @updatedDate," +
                "@lattitude, @longitude)";

    

            addPlantCommand.Parameters.AddWithValue("@plantName", plantNameTextbox.Text);
            addPlantCommand.Parameters.AddWithValue("@street", streetTextbox.Text);
            addPlantCommand.Parameters.AddWithValue("@city", cityTextbox.Text);
            addPlantCommand.Parameters.AddWithValue("@state", stateTextbox.Text);
            addPlantCommand.Parameters.AddWithValue("@zip", zipTextBox.Text);
            addPlantCommand.Parameters.AddWithValue("@phoneNumber", phoneNumberTextbox.Text);
            addPlantCommand.Parameters.AddWithValue("@productionInfo", productsProducedTextbox.Text);
            addPlantCommand.Parameters.AddWithValue("@creationUsername", DBHelper.GetCurrentUser());
            addPlantCommand.Parameters.AddWithValue("@creationDate", DateTime.Now);
            addPlantCommand.Parameters.AddWithValue("@updatedUsername", DBHelper.GetCurrentUser());
            addPlantCommand.Parameters.AddWithValue("@updatedDate", DateTime.Now);
            addPlantCommand.Parameters.AddWithValue("@lattitude", lattitude);
            addPlantCommand.Parameters.AddWithValue("@longitude", longitude);


            try
            {
                addPlantCommand.ExecuteNonQuery();
                MessageBox.Show("Plant added!");
                
                _lastID = (int)addPlantCommand.LastInsertedId;

            }
            catch(MySqlException exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show(exception.ToString());
                return;
            }
        }





        private void CheckCoordinates(double pinLat, double pinLong)
        {
            double dbLat, dbLong = 0.0;
            

            MySqlConnection connection = DBHelper.GetConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT lattitude, longitude FROM plant_location WHERE plantID=@plantID";
            command.Parameters.AddWithValue("plantID", _lastID);

            MySqlDataReader reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    dbLat = Double.Parse(reader["lattitude"].ToString());
                    dbLong = Double.Parse(reader["longitude"].ToString());

                    if(dbLat == pinLat && dbLong == pinLong)
                    {
                        MessageBox.Show($"Pin Lat: {pinLat} Pin Long: {pinLong} \n" +
                        $"DB Lat: {dbLat} DB Long: {dbLong} \n" +
                         "Coordinates Match!");
                    }
                    else
                    {
                        MessageBox.Show($"Pin Lat: {pinLat} Pin Long: {pinLong} \n" +
                  $"DB Lat: {dbLat} DB Long: {dbLong} \n" +
                   "Coordinates Do Not Match!");
                    }
               

                    break;
                }
            }

            reader.Close();

        }

        private bool IsFormValidated()
        {
            if (String.IsNullOrWhiteSpace(plantNameTextbox.Text))
            {
                MessageBox.Show("Plant name cannot be left blank.");
                return false;
            }
            else if (String.IsNullOrWhiteSpace(phoneNumberTextbox.Text))
            {
                MessageBox.Show("Phone Number cannot be left blank.");
                return false;
            }
            else if (String.IsNullOrWhiteSpace(productsProducedTextbox.Text))
            {
                MessageBox.Show("Products Produced cannot be left blank.");
                return false;
            }
            else if (String.IsNullOrWhiteSpace(streetTextbox.Text))
            {
                MessageBox.Show("Street cannot be left blank.");
                return false;
            }
            else if (String.IsNullOrWhiteSpace(cityTextbox.Text))
            {
                MessageBox.Show("City cannot be left blank.");
                return false;
            }
            else if (String.IsNullOrWhiteSpace(stateTextbox.Text))
            {
                MessageBox.Show("State cannot be left blank.");
                return false;
            }
            else if (String.IsNullOrWhiteSpace(zipTextBox.Text))
            {
                MessageBox.Show("Zip cannot be left blank.");
                return false;
            }

            return true;
        }

    }
}
