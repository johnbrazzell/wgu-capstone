using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingMapsRESTToolkit;

namespace plant_locator_tool
{
    public class BingMapsRequest
    {
        private double _latitude;
        private double _longitude;
        private double[] loc = new double[2];
        public double GetLatitude()
        {
            return _latitude;
        }

        public double GetLongitude()
        {
            return _longitude;
        }

        

        //public async void GeocodeAddress(string sessionKey, string address)
        //{
           
        //        var request = new GeocodeRequest()
        //        {


        //            Query = address,
        //            IncludeIso2 = true,
        //            IncludeNeighborhood = true,
        //            MaxResults = 1,
        //            BingMapsKey = sessionKey

        //        };

        //        var response = await request.Execute();

        //        if (response != null &&
        //            response.ResourceSets != null &&
        //            response.ResourceSets.Length > 0 &&
        //            response.ResourceSets[0].Resources != null &&
        //            response.ResourceSets[0].Resources.Length > 0)
        //        {
        //            var result = response.ResourceSets[0].Resources[0] as BingMapsRESTToolkit.Location;



        //        double[] loc = new double[2];
        //        _latitude = result.Point.Coordinates[0];
        //        _longitude = result.Point.Coordinates[1];

        //        loc.Append<double>(_latitude);
        //        loc.Append<double>(_longitude);
        //        return loc;
        //            //double lattitude = result.Point.Coordinates[0];
        //            //double longitude = result.Point.Coordinates[1];

        //           // Microsoft.Maps.MapControl.WPF.Location loc = new Microsoft.Maps.MapControl.WPF.Location(lattitude, longitude);
                  


        //        }
        //        else
        //        {
        //            System.Windows.MessageBox.Show("Address was not found");
        //            return loc;
        //        }

        //    }
    }
}
