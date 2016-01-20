using System.Collections.Generic;
using System.Linq;
using CarPerformanceComparison.Contracts;
using CarPerformanceComparison.Data;

namespace CarPerformanceComparison.Services
{
    public class CarPerformanceSimulator : ICarPerformanceSimulator
    {
        /// <summary>
        /// Creates a list of Car performance items sorted by the Car consumption ascending
        /// </summary>
        public IEnumerable<CarPerformance> ComparePerformanceOnRace(IRace Race, List<ICar> Cars)
        {
            Race.AssertNotNull();
            Cars.AssertNotNull();
            Cars.AssertNotEmpty();

            var CarsPerformance = new List<CarPerformance>();
            foreach (var Car in Cars)
            {
                var fuelConsumption = Car.GetAverageFuelConsumption(Race);
                var CarPerformance = new CarPerformance(Car.Name, fuelConsumption);
                CarsPerformance.Add(CarPerformance);
            }

            var sortedList = CarsPerformance.OrderBy(x => x.FuelConsumption).ToList();
            return sortedList;
        }
    }
}
