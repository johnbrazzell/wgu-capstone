using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_locator_tool
{
    public class Plant
    {
        public int PlantID { get; set; }
        public string PlantName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string ProductionInformation { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

 
    }
}
