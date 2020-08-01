using System;
using AutoMapper;

namespace Agiil.ObjectMaps
{
    public static class RuntimeMapperExtensions
    {
        /// <summary>
        /// Resolve a service from the mapper's dependency injection resolver.
        /// </summary>
        /// <returns>The resolved service.</returns>
        /// <param name="mapper">The mapper.</param>
        /// <typeparam name="T">The service type.</typeparam>
        public static T Resolve<T>(this IRuntimeMapper mapper)
        {
            return (T) mapper.ServiceCtor(typeof(T));
        }
    }
}
