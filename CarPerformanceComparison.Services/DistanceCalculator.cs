using CarPerformanceComparison.Contracts;
using CarPerformanceComparison.Data;
using CarPerformanceComparison.Helpers;

namespace CarPerformanceComparison.Services
{
    public class DistanceCalculator : IDistanceCalculator
    {
        public double CalculateDistance(Position p1, Position p2)
        {
            p1.AssertNotNull();
            p2.AssertNotNull();

            var distance = GeoCodeCalculator.CalculateDistanceInMeters(p1.Latitude, p1.Longitude,
                p2.Latitude, p2.Longitude);
            return distance;
        }
    }
}
