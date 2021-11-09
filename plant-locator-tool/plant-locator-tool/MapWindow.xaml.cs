using Microsoft.Maps.MapControl.WPF;
using System;
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
            Microsoft.Maps.MapControl.WPF.Location startLocation = new Microsoft.Maps.MapControl.WPF.Location(44.967243, -103.77155);
            mainMap.SetView(startLocation, 3.0);
         
            

            Pushpin testPin = new Pushpin();
            testPin.Location = startLocation;
            testPin.ToolTip = "Test";
            mainMap.Children.Add(testPin);

            mainMap.CredentialsProvider.GetCredentials((c) =>
            {
                sessionKey = c.ApplicationId;

            });

        }

        private async void GeocodeAddress(string address)
        {

            var request = new GeocodeRequest()
            {

                //Query = "New York, NY",
                Query = address,
                IncludeIso2 = true,
                IncludeNeighborhood = true,
                MaxResults = 25,
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

            }
        }

        private void addPlantMenuItem_Click(object sender, RoutedEventArgs e)
        {

       
        }
    
    }
}
