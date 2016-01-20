using System.Collections.Generic;
using System.Linq;
using CarPerformanceComparison.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarPerformanceComparison.Data;
using CarPerformanceComparison.Services;

namespace CarPerformanceComparison.Tests
{
    [TestClass]
    public class CarPerformanceTest
    {
        private CarPerformanceSimulator _carPerformance;
        private CarFactory _carFactory;
        private RaceFactory _raceFactory;
        private DistanceCalculator _distanceCalculator;

        [TestInitialize]
        public void Initialize()
        {
            _carPerformance = new CarPerformanceSimulator();
            _carFactory = new CarFactory();
            _raceFactory = new RaceFactory();
            _distanceCalculator = new DistanceCalculator();
        }

        [TestMethod]
        public void TestMinCarPerformanceSimulator()
        {
            var Cars = new List<ICar>
                              {
                                  _carFactory.Create(
                                      "Test Car 1",
                                      new ConsumptionAtSpeed(new Range<double>(0, 8), 0.7),
                                      new ConsumptionAtSpeed(new Range<double>(8, 13.5), 1.2),
                                      20),
                                  _carFactory.Create(
                                      "Test Car 2",
                                      new ConsumptionAtSpeed(new Range<double>(0, 8), 0.9),
                                      new ConsumptionAtSpeed(new Range<double>(9, 15.5), 1.7),
                                      17)
                              };

            var wayPoints = new List<Waypoint>
                                {
                                    new Waypoint(new Position(35.9516683333333, -5.74306666666667),
                                                 new WaypointInstruction(Instructions.SetSpeed, 5.0)),
                                    new Waypoint(new Position(35.6431216666667, -6.31655166666667),
                                                 new WaypointInstruction(Instructions.SpeedUpPercent, 10)),
                                    new Waypoint(new Position(33.642105, -7.57905833333333),
                                                 new WaypointInstruction(Instructions.SpeedUpPercent, 20)),
                                    new Waypoint(new Position(33.67997, -7.56830166666667),
                                                 new WaypointInstruction(Instructions.SpeedUpPercent, 30)),
                                    new Waypoint(new Position(33.6117983333333, -7.59896333333333),
                                                 new WaypointInstruction(Instructions.None, 0)),
                                    new Waypoint(new Position(34.5023266667, -7.07528166667),
                                                 new WaypointInstruction(Instructions.SlowDownPercent, 30)),
                                };

            var race = _raceFactory.Create(_distanceCalculator, wayPoints);

            var carsPerformance = _carPerformance.ComparePerformanceOnRace(race, Cars);
            var minconsumption = carsPerformance.Min(x => x.FuelConsumption);

            Assert.AreEqual(285370.99946939229, minconsumption);
        }
        
        [TestMethod]
        public void TestIsCarConsumptionPositive()
        {
            var Cars = new List<ICar>
                              {
                                  _carFactory.Create(
                                      "Test Car 1",
                                      new ConsumptionAtSpeed(new Range<double>(0, 15), 1.3),
                                      new ConsumptionAtSpeed(new Range<double>(16, 28.5), 2.5),
                                      30),
                                  _carFactory.Create(
                                      "Test Car 2",
                                      new ConsumptionAtSpeed(new Range<double>(0, 5), 0.9),
                                      new ConsumptionAtSpeed(new Range<double>(5, 10.5), 1.3),
                                      12)
                              };

            var wayPoints = new List<Waypoint>
                                {
                                    new Waypoint(new Position(33.6117983333333, -7.59896333333333),
                                                 new WaypointInstruction(Instructions.SetSpeed, 8.0)),
                                    new Waypoint(new Position(35.6431216666667, -6.31655166666667),
                                                 new WaypointInstruction(Instructions.SpeedUpPercent, 15)),
                                    new Waypoint(new Position(33.642105, -7.57905833333333),
                                                 new WaypointInstruction(Instructions.SpeedUpPercent, 20)),
                                    new Waypoint(new Position(33.6117983333333, -7.59896333333333),
                                                 new WaypointInstruction(Instructions.None, 0)),
                                    new Waypoint(new Position(34.5023266667, -7.07528166667),
                                                 new WaypointInstruction(Instructions.SlowDownPercent, 30)),
                                };

            var race = _raceFactory.Create(_distanceCalculator, wayPoints);

            var carsPerformance = _carPerformance.ComparePerformanceOnRace(race, Cars);
            var isAllPosotive = carsPerformance.All(x=>x.FuelConsumption > 0);

            Assert.IsTrue(isAllPosotive);
        }

    }
}
