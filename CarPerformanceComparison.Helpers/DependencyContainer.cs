using System;
using System.Collections.Generic;
using CarPerformanceComparison.Contracts;

namespace CarPerformanceComparison.Helpers
{
    public class DependencyContainer : IDependencyContainer
    {
        private readonly Dictionary<Type, Type> _container = new Dictionary<Type, Type>();

        private class TypeRegistration : ITypeRegistration {

            private readonly Dictionary<Type, Type> _container;

            public TypeRegistration(Dictionary<Type, Type> container, Type concreteType)
            {
                _container = container;
                this.ConcreteType = concreteType;
            }

            public Type ConcreteType { get; private set; }

            public void As<T>() 
            {
                _container.Add(typeof(T), ConcreteType);
            }
        }

        public ITypeRegistration RegisterType<T>() where T : class, new()
        {
            return new TypeRegistration(_container, typeof(T));
        }

        public T Resolve<T>()
        {
            if (!_container.ContainsKey(typeof(T))) {
                throw new ArgumentException("Implementation for " + typeof(T).Name + " has not been registered");
            }

            return (T)Activator.CreateInstance(_container[typeof(T)]);
        }
    }
}
