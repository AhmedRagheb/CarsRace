using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarPerformanceComparison.Data;
using CarPerformanceComparison.Services;

namespace CarPerformanceComparison.Tests
{
    [TestClass]
    public class RaceTest
    {
        private RaceFactory _raceFactory;
        private DistanceCalculator _distanceCalculator;

        [TestInitialize]
        public void Initialize()
        {
            _raceFactory = new RaceFactory();
            _distanceCalculator = new DistanceCalculator();
        }

        [TestMethod]
        public void TestCreateRace()
        {
            var wayPoints = new List<Waypoint>
            {
                new Waypoint(new Position(35.9516683333333,-5.74306666666667), new WaypointInstruction(Instructions.SetSpeed, 5.0)),
                new Waypoint(new Position(35.6431216666667,-6.31655166666667), new WaypointInstruction(Instructions.SpeedUpPercent, 10)),
                new Waypoint(new Position(33.642105,-7.57905833333333), new WaypointInstruction(Instructions.SpeedUpPercent, 20)),
                new Waypoint(new Position(33.67997,-7.56830166666667), new WaypointInstruction(Instructions.SpeedUpPercent, 30)),
                new Waypoint(new Position(33.6117983333333,-7.59896333333333), new WaypointInstruction(Instructions.None, 0)),
                new Waypoint(new Position(34.5023266667, -7.07528166667), new WaypointInstruction(Instructions.SlowDownPercent, 30)),
            };

            var returnVal = _raceFactory.Create(_distanceCalculator, wayPoints);
            Assert.IsNotNull(returnVal);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullDistance()
        {
            var wayPoints = new List<Waypoint>
            {
                new Waypoint(new Position(35.9516683333333,-5.74306666666667), new WaypointInstruction(Instructions.SetSpeed, 5.0)),
                new Waypoint(new Position(35.6431216666667,-6.31655166666667), new WaypointInstruction(Instructions.SpeedUpPercent, 10)),
                new Waypoint(new Position(33.642105,-7.57905833333333), new WaypointInstruction(Instructions.None, 20)),
                new Waypoint(new Position(34.5023266667, -7.07528166667), new WaypointInstruction(Instructions.SlowDownPercent, 30)),
            };

            var returnVal = _raceFactory.Create(null, wayPoints);
            Assert.IsNull(returnVal);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullWayPoints()
        {
            var returnVal = _raceFactory.Create(_distanceCalculator, null);
            Assert.IsNull(returnVal);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestEmptyWayPoints()
        {
            var returnVal = _raceFactory.Create(_distanceCalculator, new List<Waypoint>());
            Assert.IsNull(returnVal);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestEmptyWayPointsAndDistance()
        {
            var returnVal = _raceFactory.Create(null, null);
            Assert.IsNull(returnVal);
        }
    }
}
