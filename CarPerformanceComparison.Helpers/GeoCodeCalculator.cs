using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPerformanceComparison.Helpers
{
    public class GeoCodeCalculator
    {
        public const double EarthRadiusInMeters = 6371000.0;

        public static double ToRadian(double val) { return val * (Math.PI / 180); }
        public static double DiffRadian(double val1, double val2) { return ToRadian(val2) - ToRadian(val1); }

        public static double CalculateDistanceInMeters(double lat1, double lng1, double lat2, double lng2)
        {
            return EarthRadiusInMeters * 2 *
                   Math.Asin(Math.Min(1,
                       Math.Sqrt((Math.Pow(Math.Sin((DiffRadian(lat1, lat2))/2.0), 2.0) +
                                  Math.Cos(ToRadian(lat1))*Math.Cos(ToRadian(lat2))*
                                  Math.Pow(Math.Sin((DiffRadian(lng1, lng2))/2.0), 2.0)))));
        }

    }
}

