using System;
using Agiil.Domain;
using Autofac;

namespace Agiil.Tests.Bootstrap
{
  public class EnvironmentModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<RandomEnvironment>()
        .AsSelf()
        .As<IEnvironment>()
        .InstancePerLifetimeScope();
    }
  }
}
