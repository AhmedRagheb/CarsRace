
using System;
using System.Collections.Generic;
using System.Linq;
using CarPerformanceComparison.Contracts;
using CarPerformanceComparison.Data;

namespace CarPerformanceComparison.Services
{
    public class RaceFactory : IRaceFactory
    {
        public IRace Create(IDistanceCalculator distanceCalculator, IEnumerable<Waypoint> waypoints)
        {
          
                distanceCalculator.AssertNotNull();
                waypoints = waypoints as List<Waypoint> ?? waypoints.ToList();
                waypoints.AssertNotEmpty();
                waypoints.AssertNotNull();

                var Race = new RaceService(distanceCalculator, waypoints);
                return Race;
  
            
        }
    }
}

