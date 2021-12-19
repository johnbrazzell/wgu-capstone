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

   

        private string sessionKey;
        private Microsoft.Maps.MapControl.WPF.Location _startLocation = new Microsoft.Maps.MapControl.WPF.Location(39.8282, -98.5795);
        private Pushpin _searchPin = new Pushpin();
        

        public MapWindow()
        {
            InitializeComponent();

            mainMap.SetView(_startLocation, 5.0);
            //Set the search pin to the color green
            _searchPin.Background = new SolidColorBrush(Color.FromArgb(120, 0, 255, 0));
            _searchPin.Name = "searchPin";


            if (!DBHelper.GetAdminStatus())
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
            for (int i = 0; i < mainMap.Children.Count; i++)
            {
                if (mainMap.Children[i].Uid == id.ToString())
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

            while (reader.Read())
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

            if (sender is Pushpin)
            {
                // TODO ADD QUERY TO PULL DATA AND ADD TO SIDE BAR
                Pushpin clickedPin = sender as Pushpin;
                clickedPin.ReleaseMouseCapture();
                plantNameLabel.Content = clickedPin.Uid;
                int id = Int32.Parse(clickedPin.Uid);

                if (clickedPin.Name != _searchPin.Name)
                {
                    LoadPlantData(id);
                }

            }
        }

        private void LoadPlantData(int id)
        {
            MySqlCommand command = DBHelper.GetConnection().CreateCommand();
            command.CommandText = "SELECT * FROM plant_location WHERE plantID=@plantID";
            command.Parameters.AddWithValue("@plantID", id);

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //Populate side panel with plant data from selected pin
                    plantNameLabel.Content = "Plant Name: " + reader["plantName"];
                    phoneNumberLabel.Content = "Plant Phone: " + reader["phoneNumber"];
                    streetLabel.Content = "Plant Street: " + reader["street"];
                    cityLabel.Content = "Plant City: " + reader["city"];
                    stateLabel.Content = "Plant State: " + reader["state"];
                    zipLabel.Content = "Plant Zip: " + reader["zip"];
                    productionInfoLabel.Text = "Produces: " + reader["productionInfo"];
                    lastUpdatedByLabel.Content = "Last Updated By: " + reader["updatedBy"];
                    lastUpdatedDateLabel.Content = "Update Date: " + reader["updatedDate"];
                }

                reader.Close();
            }
            else
            {
                reader.Close();
            }
        }

        private async void AddressSearch(string address)
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


                //Add a temporary marker to the map based on users search
                if (_searchPin.Location != loc)
                {
                    mainMap.Children.Remove(_searchPin);
                    _searchPin.Location = loc;
                    _searchPin.ToolTip = searchBar.Text;
                    mainMap.Children.Add(_searchPin);
                    mainMap.SetView(_searchPin.Location, 8.0);
                }



            }
            else
            {
                MessageBox.Show("Address not found");
            }
        }

        private void addPlantMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(WindowOpenCheck.IsWindowOpen("AddUserWindow"))
            {
                return;
            }
            else
            {
                AddPlantWindow plantWindow = new AddPlantWindow(this);
                plantWindow.Show();

            }

        }

        private void addUserMenuItem_Click(object sender, RoutedEventArgs e)
        { 
            if(WindowOpenCheck.IsWindowOpen("AddUserWindow"))
            {
                return;
            }
            else
            {

                AddUserWindow addUserWindow = new AddUserWindow();
                addUserWindow.Show();
            }
        }

        private void viewUsersMenuItem_Click(object sender, RoutedEventArgs e)
        {

            if(WindowOpenCheck.IsWindowOpen("ViewUsersWindow"))
            {
                return;
            }
            else
            {
                ViewUsersWindow viewUserWindow = new ViewUsersWindow();
                viewUserWindow.Show();
            }

        }

        private void changePasswordMenuItem_Click(object sender, RoutedEventArgs e)
        {
         
            if(WindowOpenCheck.IsWindowOpen("ChangePasswordWindow"))
            {
                return;
            }
            else
            {
                ChangePasswordWindow window = new ChangePasswordWindow();
                window.Show();
            }
       
        }


        private void searchButton_Click(object sender, RoutedEventArgs e)
        {

            if(String.IsNullOrEmpty(searchBar.Text))
            {
                return;
            }
            else
            {

                AddressSearch(searchBar.Text);
            }
        }

        private void quitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DBHelper.CloseConnection();
            Application.Current.Shutdown();
        }

        private void viewPlantMenuItem_Click(object sender, RoutedEventArgs e)
        {

            

            if(WindowOpenCheck.IsWindowOpen("ViewPlantsWindow"))
            {
                return;
            }
            else
            {
                ViewPlantsWindow window = new ViewPlantsWindow(this);
                window.Show();
            }
 
          
        }


        private void reports_Click(object sender, RoutedEventArgs e)
        {
            if(WindowOpenCheck.IsWindowOpen("ReportWindow"))
            {
                return;
            }
            else
            {
                ReportWindow window = new ReportWindow();
                window.Show();

            }

        }
    }
}
