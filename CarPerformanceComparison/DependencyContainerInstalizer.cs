using CarPerformanceComparison.Contracts;
using CarPerformanceComparison.Helpers;
using CarPerformanceComparison.Services;

namespace CarPerformanceComparison
{
    public static class  DependencyContainerInstalizer
    {
        public static IDependencyContainer Container { get; private set; }
        public static void Instalize()
        {
            Container = new DependencyContainer();
            Container.RegisterType<CarPerformanceSimulator>().As<ICarPerformanceSimulator>();
            Container.RegisterType<RaceFactory>().As<IRaceFactory>();
            Container.RegisterType<CarFactory>().As<ICarFactory>();
            Container.RegisterType<DistanceCalculator>().As<IDistanceCalculator>();
        }
    }
}
