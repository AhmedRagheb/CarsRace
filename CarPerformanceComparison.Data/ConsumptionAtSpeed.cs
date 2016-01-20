using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPerformanceComparison.Data
{
    /// <summary>
    /// Defines a average consumption in tonnes/day(24h) within a speed range
    /// </summary>
    public class ConsumptionAtSpeed
    {
        public Range<double> Range { get; private set; }
        public double Consumption { get; set; }

        public ConsumptionAtSpeed(Range<double> range, double consumption)
        {
            range.AssertNotNull();
            consumption.AssertPositive();

            this.Range = range;
            this.Consumption = consumption;
        }
    }
}
