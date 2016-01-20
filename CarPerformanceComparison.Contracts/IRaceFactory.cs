using System.Collections.Generic;
using CarPerformanceComparison.Data;

namespace CarPerformanceComparison.Contracts
{
    public interface IRaceFactory
    {
        IRace Create(
            IDistanceCalculator distanceCalculator,
            IEnumerable<Waypoint> waypoints);
    }
}
