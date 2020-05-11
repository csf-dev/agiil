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
            builder
                .Register(GetMapper)
                .SingleInstance();
        }

        MapperConfiguration GetMapperConfiguration(IComponentContext ctx)
            => ctx.Resolve<IMapperConfigurationFactory>().GetConfiguration();

        IMapper GetMapper(IComponentContext ctx)
        {
            var config = ctx.Resolve<MapperConfiguration>();
            var scope = ctx.Resolve<ILifetimeScope>();
            var mapper = config.CreateMapper(scope.Resolve);

            return mapper;
        }
    }
}
