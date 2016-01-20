using System;
using System.Linq;
using CarPerformanceComparison.Contracts;
using CarPerformanceComparison.Data;
using CarPerformanceComparison.Helpers;

namespace CarPerformanceComparison.Services
{
    public class CarFactory : ICarFactory
    {
        public ICar Create(string name, ConsumptionAtSpeed lowSpeedConsumption, ConsumptionAtSpeed highSpeedConsumption, double maxSpeed)
        {
            lowSpeedConsumption.AssertNotNull();
            highSpeedConsumption.AssertNotNull();
            maxSpeed.AssertPositive();
            maxSpeed.AssertLargerThan(0);
            
            var Car = new CarService(name, lowSpeedConsumption, highSpeedConsumption, maxSpeed);
            return Car;
        }
    }


}
