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
        .RegisterType<InMemoryDataManager>()
        .SingleInstance();

      builder
        .Register(GetQuery)
        .AsSelf()
        .As<IQuery>();

      builder
        .RegisterType<InMemoryPersister>()
        .AsSelf()
        .As<IPersister>();

      builder
        .Register(CreateEntityData)
        .AsSelf()
        .As<IEntityData>();

      builder
        .RegisterType<InMemoryIdentityGenerator>()
        .AsSelf()
        .As<IIdentityGenerator>();

    }

    IdentityGeneratingEntityData CreateEntityData(IComponentContext ctx)
    {
      return new IdentityGeneratingEntityData(ctx.Resolve<IQuery>(),
                                              ctx.Resolve<IPersister>(),
                                              ctx.Resolve<IIdentityGenerator>());
    }

    InMemoryQuery GetQuery(IComponentContext ctx)
    {
      var manager = ctx.Resolve<InMemoryDataManager>();
      return manager.CurrentQuery;
    }
  }
}
