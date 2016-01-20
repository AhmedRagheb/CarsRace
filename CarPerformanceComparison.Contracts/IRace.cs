using System.Collections.Generic;
using CarPerformanceComparison.Data;

namespace CarPerformanceComparison.Contracts
{
    public interface IRace
    {
        IEnumerable<Waypoint> Waypoints { get; }

        double GetDistanceForLeg(Position position1, Position position2);
    }
}
