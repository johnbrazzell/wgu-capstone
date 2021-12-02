using System;
using Microsoft.Maps.MapControl.WPF;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Ubiety.Dns.Core;
using System.Xml;
using System.Runtime.Serialization.Json;
using BingMapsRESTToolkit;

namespace plant_locator_tool
{
   
    public partial class MapWindow : Window
    {
        
       //Chose the map start location to center on the middle of the U.S.  
       // Location startLocation = new Location(44.967243, -103.77155);
        public string testLat = String.Empty;
        public string testLong = String.Empty;

        string sessionKey;
      

        public MapWindow()
        {
            InitializeComponent();
            if(!DBHelper.GetAdminStatus())
            {
                adminOptions.IsEnabled = false;
            }

            mainMap.CredentialsProvider.GetCredentials((c) =>
            {
                sessionKey = c.ApplicationId;

            });

            LoadPinsFromDatabase();
        }


        public void AddPinToMap(int id, double latittude, double longitude)
        {
            Pushpin pin = new Pushpin();
            pin.Uid = id.ToString();
            pin.Location = new Microsoft.Maps.MapControl.WPF.Location(latittude, longitude);
            pin.MouseDown += Pin_MouseDown;
            mainMap.Children.Add(pin);

            

        }


        public void RemovePinFromMap(int id)
        {
            for(int i = 0; i < mainMap.Children.Count; i++)
            {
                if(mainMap.Children[i].Uid == id.ToString())
                {
                    Pushpin pinToRemove = mainMap.Children[i] as Pushpin;
                    mainMap.Children.Remove(pinToRemove);
                }
            }
        }


        private void LoadPinsFromDatabase()
        {
            MySqlCommand command = DBHelper.GetConnection().CreateCommand();
            command.CommandText = "SELECT * FROM plant_location";

            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                string id = reader["plantID"].ToString();
                string lat = reader["lattitude"].ToString();
                string longit = reader["longitude"].ToString();

               
                AddPinToMap(Int32.Parse(id), Double.Parse(lat), Double.Parse(longit));
            }

            reader.Close();
        }

        private void Pin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            if(sender is Pushpin)
            {
                Pushpin clickedPin = sender as Pushpin;
                clickedPin.ReleaseMouseCapture();
                plantNameLabel.Content = clickedPin.Uid;
                
            }
        }

        private async void SearchView(string address)
        {

            var request = new GeocodeRequest()
            {

        
                Query = address,
                IncludeIso2 = true,
                IncludeNeighborhood = true,
                MaxResults = 1,
                BingMapsKey = sessionKey

            };

            var response = await request.Execute();

            if (response != null &&
                response.ResourceSets != null &&
                response.ResourceSets.Length > 0 &&
                response.ResourceSets[0].Resources != null &&
                response.ResourceSets[0].Resources.Length > 0)
            {
                var result = response.ResourceSets[0].Resources[0] as BingMapsRESTToolkit.Location;



             

                double lattitude = result.Point.Coordinates[0];
                double longitude = result.Point.Coordinates[1];

                Microsoft.Maps.MapControl.WPF.Location loc = new Microsoft.Maps.MapControl.WPF.Location(lattitude, longitude);
                mainMap.SetView(loc, 8.0);
           

            }
            else
            {
                MessageBox.Show("Address not found");
            }
        }

        private void addPlantMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddPlantWindow plantWindow = new AddPlantWindow(this);
            plantWindow.Show();
       
        }

        private void addUserMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();

            addUserWindow.Show();
        }

        private void viewUsersMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ViewUsersWindow viewUserWindow = new ViewUsersWindow();
            viewUserWindow.Show();
        }

        private void changePasswordMenuItem_Click(object sender, RoutedEventArgs e)
        {
            
            ChangePasswordWindow window = new ChangePasswordWindow();
            window.Show();
        }


        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchView(searchBar.Text);
        }

        private void quitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void viewPlantMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ViewPlantsWindow window = new ViewPlantsWindow(this);
            window.Show();
        }
    }
}
