﻿using System;
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

            //geocode the address and save to DB
            GeocodeAddress();


        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        public async void GeocodeAddress()
        {
          

            var request = new GeocodeRequest()
            {

                //Query = "New York, NY",
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
                //MessageBox.Show("Lat: " + latitude.ToString() + "Long:" + longitude.ToString());
                AddPlantToDatabase(latitude, longitude);

                _mapWindow.AddPinToMap(_lastID, latitude, longitude);

                //_pin.Uid = _lastID.ToString();
                //_pin.Location = newLocation;
               
                ////_pin.Name = _lastID.ToString();
                //_pin.Content = plantNameTextbox.Text;
                //_pin.ToolTip = _pin.Content;
                //_mapWindow.mainMap.Children.Add(_pin);


                

            }
            else
            {
                MessageBox.Show("Address not found");
            }
        }


        private void AddPlantToDatabase(double lattitude, double longitude)
        {
            MySqlCommand addPlantCommand = DBHelper.GetConnection().CreateCommand();
            addPlantCommand.CommandText = "INSERT INTO plant_location (plantName, plantAddress, phoneNumber, " +
                "productionInfo, createdBy, creationDate, updatedBy, updatedDate, lattitude, longitude) " +
                "VALUES(@plantName, @plantAddress, @phoneNumber, @productionInfo, @creationUsername," +
                "@creationDate, @updatedUsername, @updatedDate," +
                "@lattitude, @longitude)";

            string plantAddress = $"{streetTextbox.Text} {cityTextbox.Text} {stateTextbox.Text} {zipTextBox.Text}";

            addPlantCommand.Parameters.AddWithValue("@plantName", plantNameTextbox.Text);
            addPlantCommand.Parameters.AddWithValue("@plantAddress", plantAddress);
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
                //call pin function on main map instead of handling here
                //this way each new pin can be registered to an OnClickEvent
                //Loading pins should be handled on the main map
            }
            catch(MySqlException exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show(exception.ToString());
                return;
            }
        }
    }
}
