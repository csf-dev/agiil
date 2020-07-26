using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Builder;
using CSF.Configuration;

namespace Agiil.Bootstrap
{
    public static class ContainerBuilderExtensions
    {
        /// <summary>
        /// Registers a configuration type to be read by an instance of <see cref="IConfigurationReader"/>.
        /// </summary>
        /// <returns>An Autofac registration builder for the specified configuration type.</returns>
        /// <param name="builder">An Autofac container builder.</param>
        /// <typeparam name="T">The type of the configuration section.</typeparam>
        public static IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> RegisterConfiguration<T>(this ContainerBuilder builder)
            where T : ConfigurationSection
        {
            return builder.Register(ctx => {
                var configReader = ctx.Resolve<IConfigurationReader>();
                return configReader.ReadSection<T>();
            });
        }

        /// <summary>
        /// Registers a configuration type to be read by an instance of <see cref="IConfigurationReader"/>, from a specified path in the configuration file.
        /// </summary>
        /// <returns>An Autofac registration builder for the specified configuration type.</returns>
        /// <param name="builder">An Autofac container builder.</param>
        /// <param name="path">The configuration file path.</param>
        /// <typeparam name="T">The type of the configuration section.</typeparam>
        public static IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> RegisterConfiguration<T>(this ContainerBuilder builder,
                                                                                                                   string path)
            where T : ConfigurationSection
        {
            return builder.Register(ctx => {
                var configReader = ctx.Resolve<IConfigurationReader>();
                return configReader.ReadSection<T>(path);
            });
        }

        /// <summary>
        /// Performs a bulk-registration of all open-generic types in the specified assemblies.  These are registered only as
        /// themselves, and not as any interfaces.
        /// </summary>
        /// <param name="builder">An Autofac container builder.</param>
        /// <param name="assemblies">The assemblies to scan for types.</param>
        public static void BulkRegisterAllOpenGenericTypesInAssemblies(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            if(assemblies == null)
                throw new ArgumentNullException(nameof(assemblies));

            var types = assemblies
                .SelectMany(x => x.GetExportedTypes())
                .Where(x => x.IsClass && !x.IsAbstract && !typeof(Delegate).IsAssignableFrom(x) && x.IsGenericTypeDefinition)
                .ToList();

            foreach(var type in types)
                builder.RegisterGeneric(type);
        }
    }
}
