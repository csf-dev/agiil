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
      builder.RegisterType<MapperConfigurationFactory>();

      builder
        .Register(ctx => {
          var factory = ctx.Resolve<MapperConfigurationFactory>();
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
