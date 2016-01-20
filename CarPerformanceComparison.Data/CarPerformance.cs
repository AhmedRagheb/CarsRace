using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarPerformanceComparison.Data
{
    public sealed class CarPerformance
    {
        public string CarName { get; private set; }
        public double FuelConsumption { get; private set; }

        public CarPerformance(string carName, double fuelConsumption)
        {
            carName.AssertNotNull();
            fuelConsumption.AssertPositive();

            this.CarName = carName;
            this.FuelConsumption = fuelConsumption;
        }

    }
}
