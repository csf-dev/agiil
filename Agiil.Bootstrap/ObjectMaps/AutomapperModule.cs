using System;
using Agiil.ObjectMaps;
using Autofac;
using AutoMapper;

namespace Agiil.Bootstrap.ObjectMaps
{
    public class AutomapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register(GetMapperConfiguration)
                .SingleInstance();

            builder.Register(GetMapper);
        }

        MapperConfiguration GetMapperConfiguration(IComponentContext ctx)
            => ctx.Resolve<IMapperConfigurationFactory>().GetConfiguration();

        IMapper GetMapper(IComponentContext ctx)
        {
            var config = ctx.Resolve<MapperConfiguration>();
            var scope = ctx.Resolve<ILifetimeScope>();

            // Looking at https://github.com/AutoMapper/AutoMapper/blob/v6.0.2/src/AutoMapper/MapperConfiguration.cs#L250
            // we can see that this is a trivially cheap operation, OK to happen as often as we need.
            var mapper = config.CreateMapper(scope.Resolve);

            return mapper;
        }


    }
}
