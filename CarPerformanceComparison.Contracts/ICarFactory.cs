using CarPerformanceComparison.Data;

namespace CarPerformanceComparison.Contracts
{
    public interface ICarFactory
    {
        ICar Create(
            string name, 
            ConsumptionAtSpeed lowSpeedConsumption, 
            ConsumptionAtSpeed highSpeedConsumption, 
            double maxSpeed);
    }
}
