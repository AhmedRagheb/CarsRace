using CarPerformanceComparison.Data;

namespace CarPerformanceComparison.Contracts
{
    public interface ICar
    {
        string Name { get; }
        double GetAverageFuelConsumption(IRace race);
        double CurrentSpeed { get; }
        double MaxSpeed { get; }

        /// <summary>
        /// The fuel consumption at low speed 
        /// </summary>
        ConsumptionAtSpeed LowSpeedConsumption { get; }

        /// <summary>
        /// The fuel consumption at high speed
        /// </summary>
        ConsumptionAtSpeed HighSpeedConsumption { get; }
    }
}
