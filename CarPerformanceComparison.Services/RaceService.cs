using System;
using System.Collections.Generic;
using CarPerformanceComparison.Contracts;
using CarPerformanceComparison.Data;

namespace CarPerformanceComparison.Services
{
    class RaceService : IRace
    {
        public RaceService(IDistanceCalculator distanceCalculator, IEnumerable<Waypoint> waypoints)
        {
            DistanceCalculator = distanceCalculator;
            Waypoints = waypoints;
        }

        public IEnumerable<Waypoint> Waypoints { get; private set; }
        public IDistanceCalculator DistanceCalculator { get; private set; }
        public double GetDistanceForLeg(Position position1, Position position2)
        {
            var distance = DistanceCalculator.CalculateDistance(position1, position2);
            return distance;
        }


    }
}
