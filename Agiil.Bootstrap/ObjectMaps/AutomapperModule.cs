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
        .RegisterType<ProfileTypesProvider>()
        .As<IProfileTypesProvider>();

      builder
        .RegisterType<MapperConfigurationFactory>()
        .As<IMapperConfigurationFactory>();

      builder
        .Register(ctx => {
          var factory = ctx.Resolve<IMapperConfigurationFactory>();
          return factory.GetConfiguration();
        })
        .SingleInstance();

      builder.Register(ctx => {
        var config = ctx.Resolve<MapperConfiguration>();
        return config.CreateMapper();
      });
    }
  }
}
