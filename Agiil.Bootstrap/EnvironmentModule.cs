using System;
using Agiil.Domain;
using Autofac;

namespace Agiil.Bootstrap
{
  public class EnvironmentModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<CurrentEnvironment>()
        .As<IEnvironment>();
    }
  }
}
