using System;
using System.Collections.Generic;

namespace game.service
{
    public class ServiceLocator
    {
        private IDictionary<object, IService> services;

        public ServiceLocator()
        {
            services = new Dictionary<object, IService>();
        }

        /// <summary>
        /// Retrieves a service of the specified type from the service collection.
        /// </summary>
        /// <typeparam name="T">The type of the service to be retrieved.</typeparam>
        /// <returns>An instance of the requested service of type <typeparamref name="T"/>.</returns>
        /// <remarks>
        /// This method attempts to retrieve a service from a collection of registered services using its type as the key.
        /// If the service is found, it is cast to the specified type and returned.
        /// If the service is not registered, a KeyNotFoundException is caught, and an ApplicationException is thrown with a message indicating that the requested service is not registered.
        /// This method is useful in dependency injection scenarios where services are registered and resolved at runtime.
        /// </remarks>
        /// <exception cref="ApplicationException">Thrown when the requested service is not registered in the service collection.</exception>
        public T GetService<T>()
        {
            try
            {
                return (T)services[typeof(T)];
            }
            catch (KeyNotFoundException)
            {
                throw new ApplicationException("The requested service is not registered");
            }
        }

        /// <summary>
        /// Registers a service of type <typeparamref name="T"/> in the service collection.
        /// </summary>
        /// <typeparam name="T">The type of the service to be registered, which must implement <see cref="IService"/>.</typeparam>
        /// <param name="service">The instance of the service to be registered.</param>
        /// <remarks>
        /// This method allows for the registration of a service within a dependency injection container.
        /// The service is stored in a dictionary using its type as the key, enabling later retrieval
        /// of the service instance when needed. The generic type parameter <typeparamref name="T"/>
        /// enforces that only types implementing the <see cref="IService"/> interface can be registered,
        /// ensuring type safety and consistency in the service collection.
        /// </remarks>
        public void RegisterService<T>(T service) where T: IService
        {
            services[typeof(T)] = service;
        }
    }
}