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
      builder.Register(GetMapperConfiguration);

      builder.Register(GetMapper);
    }

    MapperConfiguration GetMapperConfiguration(IComponentContext ctx)
      => ctx.Resolve<IMapperConfigurationFactory>().GetConfiguration();

    IMapper GetMapper(IComponentContext ctx)
      => ctx.Resolve<MapperConfiguration>().CreateMapper();
  }
}
