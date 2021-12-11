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

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public async void GeocodeAddress(string sessionKey, string address)
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




                this.Latitude = result.Point.Coordinates[0];
                this.Longitude = result.Point.Coordinates[1];
                    //double lattitude = result.Point.Coordinates[0];
                    //double longitude = result.Point.Coordinates[1];

                   // Microsoft.Maps.MapControl.WPF.Location loc = new Microsoft.Maps.MapControl.WPF.Location(lattitude, longitude);
                  


                }
            }
    }
}
