using System;
using Agiil.ObjectMaps;
using Autofac;

namespace Agiil.Bootstrap.ObjectMaps
{
  public class AutomapperResolversModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<IdentityValueResolver>();
      builder.RegisterGeneric(typeof(GetEntityByIdentityValueResolver<>));
      builder.RegisterGeneric(typeof(GetEntityByIdentityResolver<>));
      builder.RegisterGeneric(typeof(CreateIdentityResolver<>));
    }
  }
}
