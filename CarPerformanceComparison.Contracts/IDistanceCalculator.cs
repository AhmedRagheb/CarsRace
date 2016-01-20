using CarPerformanceComparison.Data;

namespace CarPerformanceComparison.Contracts
{
    public interface IDistanceCalculator
    {
        /// <summary>
        /// Calculates the distance between 2 coordinates
        /// </summary>
        /// <returns>Distance in meters</returns>
        double CalculateDistance(Position p1, Position p2);
    }
}
