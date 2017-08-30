using System;
using Agiil.Tests;
using Autofac;
using CSF.Data;
using CSF.Data.Entities;
using Agiil.Web.Data;

namespace Agiil.Web.Bootstrap
{
  public class DataModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .Register(ctx => InMemoryDatabase.Current)
        .AsSelf()
        .As<IQuery>();

      builder
        .RegisterType<InMemoryPersister>()
        .AsSelf()
        .As<IPersister>();

      builder
        .RegisterGeneric(typeof(IdentityCreatingRepository<>))
        .As(typeof(IRepository<>));
    }
  }
}
