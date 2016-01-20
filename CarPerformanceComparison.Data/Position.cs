using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPerformanceComparison.Data
{
    public class Position
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Position()
        {

        }

        public Position(double lat, double lon)
        {
            this.Longitude = lon;
            this.Latitude = lat;
        }
    }
}
