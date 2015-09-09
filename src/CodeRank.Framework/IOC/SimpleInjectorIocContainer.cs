using System;

using SimpleInjector;

namespace CodeRank.Framework.IOC
{
    /// <summary>
    /// IoC container implementation - SimpleInjector 
    /// </summary>
    public class SimpleInjectorIocContainer
    {
        /// <summary>
        ///  solution's container
        /// </summary>
        private static Container container;

        /// <summary>
        /// Initializes a new instance of the SimpleInjectorIocContainer class.
        /// </summary>
        public SimpleInjectorIocContainer()
        {
            CreateContainer();
        }

        /// <summary>
        /// initalizes the configuration
        /// </summary>
        public void InitializeContainer()
        {
            CreateContainer();
        }

        /// <summary>
        /// Gets the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the instance.</typeparam>
        /// <returns>Concrete implementation of the T.</returns>
        public T Get<T>()
            where T : class
        {
            return container.GetInstance<T>();
        }

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <typeparam name="TInterface">The specified interface.</typeparam>
        /// <typeparam name="TImplementor">The concrete instance.</typeparam>
        public void Register<TInterface, TImplementor>()
            where TImplementor : class, TInterface
            where TInterface : class
        {
            container.Register<TInterface, TImplementor>();
        }

        /// <summary>
        /// Injects the specified instance.
        /// </summary>
        /// <typeparam name="T">The type of the instance.</typeparam>
        /// <param name="instance">The concrete instance.</param>
        public void Inject<T>(T instance)
            where T : class
        {
            container.InjectProperties(instance);
        }

        /// <summary>
        /// Registers a factory that can be used for creating proper
        /// instance according to the specified interface.
        /// </summary>
        /// <typeparam name="TInterface">Specifies the interface for which a concrete instance has to be registered.</typeparam>
        /// <param name="factory">A factory delegate that has to be used for creating the requsted instance.</param>
        public void Register<TInterface>(Func<TInterface> factory) where TInterface : class
        {
            container.Register(factory);
        }

        /// <summary>
        /// Injects the container for test purpose.
        /// </summary>
        /// <param name="testContainer">The test container.</param>
        internal static void InjectContainerForTestPurpose(Container testContainer)
        {
            container = testContainer;
        }

        /// <summary>
        /// creates the container if it is not created yet
        /// </summary>
        private static void CreateContainer()
        {
            if (container == null)
            {
                container = new Container();
            }
        }
    }
}
