
namespace CarPerformanceComparison.Contracts
{
    public interface IDependencyContainer
    {
        ITypeRegistration RegisterType<T>() where T : class, new();
        T Resolve<T>();
    }

    public interface ITypeRegistration {
        void As<T>();
    }
}
