using System.Collections.Generic;
using CarPerformanceComparison.Data;

namespace CarPerformanceComparison.Contracts
{
    public interface ICarPerformanceSimulator
    {
        /// <summary>
        /// Creates a list of Car perforamance items sorted by the Car consumption ascending
        /// </summary>
        IEnumerable<CarPerformance> ComparePerformanceOnRace(IRace race, List<ICar> cars);
    }
}
