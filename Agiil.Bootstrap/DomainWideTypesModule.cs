using System;
using Agiil.Domain;
using Autofac;

namespace Agiil.Bootstrap
{
  public class DomainWideTypesModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<ValidationResultInterpreter>()
        .AsSelf()
        .AsImplementedInterfaces();
    }
  }
}
