using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using CarPerformanceComparison.Contracts;
using CarPerformanceComparison.Data;

namespace CarPerformanceComparison
{
    public class Program
    {
        public static IDependencyContainer Container { get; set; }

        static Program()
        {
            //Register dependencies
            DependencyContainerInstalizer.Instalize();
            Container = DependencyContainerInstalizer.Container;
        }

        static void Main(string[] args)
        {
            //Load waypoint data
            IEnumerable<Waypoint> waypoints = LoadWayPointData();

            //Create some test Cars
            List<ICar> cars = CreateTestCars();

            // Run Simulator
            RunSimulator(waypoints, cars);
        }

        static IEnumerable<Waypoint> LoadWayPointData()
        {
            string fileData = File.ReadAllText("../../Data/input.json").Replace(Environment.NewLine, "");
            var data = new[] { new { lat = 0.0, lon = 0.0 } };
            var waypointsJson = JsonConvert.DeserializeAnonymousType(fileData, data);

            //Create waypoint objects
            IEnumerable<Waypoint> waypoints = waypointsJson.Select(x => new Waypoint(new Position(x.lat, x.lon), new WaypointInstruction(Instructions.None, 0))).ToList();
            return waypoints;
        }

        static List<ICar> CreateTestCars()
        {
            var carFactory = Container.Resolve<ICarFactory>();
            List<ICar> cars = new List<ICar>()
            {
                carFactory.Create(
                    name: "Test Car 1", 
                    lowSpeedConsumption: new ConsumptionAtSpeed(new Range<double>(0, 5), 0.5), 
                    highSpeedConsumption: new ConsumptionAtSpeed(new Range<double>(5, 9.3), 0.7), 
                    maxSpeed: 20),
                carFactory.Create(
                    name: "Test Car 2", 
                    lowSpeedConsumption: new ConsumptionAtSpeed(new Range<double>(0, 4), 0.8), 
                    highSpeedConsumption: new ConsumptionAtSpeed(new Range<double>(4, 8.1), 0.3), 
                    maxSpeed: 17)
            };

            return cars;
        }

        static void RunSimulator(IEnumerable<Waypoint> waypoints, List<ICar> cars)
        {
            var calculator = Container.Resolve<IDistanceCalculator>();
            var voyageFactory = Container.Resolve<IRaceFactory>();
            var simulator = Container.Resolve<ICarPerformanceSimulator>();

            //Create a voyage
            IRace voyage = voyageFactory.Create(calculator, waypoints);

            //Run the simulation
            IEnumerable<CarPerformance> res = simulator.ComparePerformanceOnRace(voyage, cars);
            foreach (var item in res)
            {
                Console.WriteLine(item.CarName + " : " + item.FuelConsumption);
            }

            Console.ReadLine();
        }

    }
}
