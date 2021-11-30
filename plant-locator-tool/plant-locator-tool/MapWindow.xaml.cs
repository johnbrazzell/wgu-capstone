﻿using System;
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
    /// <summary>
    /// http://dev.virtualearth.net/REST/v1/Locations/US/{adminDistrict}/{postalCode}/{locality}/{addressLine}?includeNeighborhood={includeNeighborhood}&include={includeValue}&maxResults={maxResults}&key={BingMapsKey}
    /// http://dev.virtualearth.net/REST/v1/Locations/US/-/10548/-/-?key={AkbVNqEV1maGXyLUBXjt4QnK1H6LgGdg3UmVxVPEjPbVFtp_a6uqmp7WF-pQQ6n}
    /// Interaction logic for MapWindow.xaml
    /// </summary>
    public partial class MapWindow : Window
    {
        
        //Chose the map start location to center on the middle of the U.S.  
       // Location startLocation = new Location(44.967243, -103.77155);
        public string testLat = String.Empty;
        public string testLong = String.Empty;
        //string test = "https://dev.virtualearth.net/REST/version/restApi/resourcePath?queryParameters&key={AkbVNqEV1maGXyLUBXjt4QnK1H6LgGdg3UmVxVPEjPbVFtp_a6uqmp7WF-pQQ6n_}";
        //string test = "http://dev.virtualearth.net/REST/v1/Locations/US/-/10548/-/-?&key={AkbVNqEV1maGXyLUBXjt4QnK1H6LgGdg3UmVxVPEjPbVFtp_a6uqmp7WF-pQQ6n}";
       // string test = "http://dev.virtualearth.net/REST/v1/Locations/US/WA/Redmond/1%20Microsoft%20Way?output=xml&key={AkbVNqEV1maGXyLUBXjt4QnK1H6LgGdg3UmVxVPEjPbVFtp_a6uqmp7WF-pQQ6n}";
        string sessionKey;
      

        public MapWindow()
        {
            InitializeComponent();
            if(!DBHelper.GetAdminStatus())
            {
                adminOptions.IsEnabled = false;
            }

            LoadPinsFromDatabase();
            //Microsoft.Maps.MapControl.WPF.Location startLocation = new Microsoft.Maps.MapControl.WPF.Location(44.967243, -103.77155);
            //mainMap.SetView(startLocation, 3.0);
         
            

            //Pushpin testPin = new Pushpin();
            //testPin.Location = startLocation;
            //testPin.ToolTip = "Test";
            //mainMap.Children.Add(testPin);

            mainMap.CredentialsProvider.GetCredentials((c) =>
            {
                sessionKey = c.ApplicationId;

            });

        }


        public void AddPinToMap(int id, double latittude, double longitude)
        {
            Pushpin pin = new Pushpin();
            pin.Uid = id.ToString();
            pin.Location = new Microsoft.Maps.MapControl.WPF.Location(latittude, longitude);
            pin.MouseDown += Pin_MouseDown;
            mainMap.Children.Add(pin);


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

        //public async void GeocodeAddress(string plantName, string address)
        //{

        //    var request = new GeocodeRequest()
        //    {

        //        //Query = "New York, NY",
        //        Query = address,
        //        IncludeIso2 = true,
        //        IncludeNeighborhood = true,
        //        MaxResults = 1,
        //        BingMapsKey = sessionKey

        //    };

        //    var response = await request.Execute();

        //    if (response != null &&
        //        response.ResourceSets != null &&
        //        response.ResourceSets.Length > 0 &&
        //        response.ResourceSets[0].Resources != null &&
        //        response.ResourceSets[0].Resources.Length > 0)
        //    {
        //        var result = response.ResourceSets[0].Resources[0] as BingMapsRESTToolkit.Location;



        //        Pushpin pin = new Pushpin();

        //        double latitude = result.Point.Coordinates[0];
        //        double longitude = result.Point.Coordinates[1];
        //        pin.Location.Latitude = latitude;
        //        pin.Location.Longitude = longitude;

        //        pin.Name = plantName;
        //        pin.ToolTip = pin.Name;
        //        mainMap.Children.Add(pin);
        //       // pin.Location =;

        //    }
        //    else
        //    {
        //        MessageBox.Show("Address not found");
        //    }
        //}

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

        private void quitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //create pin method here
    }
}
