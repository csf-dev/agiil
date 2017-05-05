using System;
using Autofac;
using CSF.Data;
using CSF.Data.Entities;

namespace Agiil.Tests.Bootstrap
{
  public class DataModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<InMemoryQuery>()
        .AsSelf()
        .As<IQuery>()
        .InstancePerLifetimeScope();

      builder
        .RegisterType<InMemoryPersister>()
        .AsSelf()
        .As<IPersister>()
        .InstancePerLifetimeScope();

      builder
        .RegisterGeneric(typeof(IdentityCreatingRepository<>))
        .As(typeof(IRepository<>));
    }
  }
}
