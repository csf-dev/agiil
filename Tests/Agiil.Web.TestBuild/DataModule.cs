using System;
using Agiil.Tests;
using Autofac;
using CSF.Data;
using CSF.Data.Entities;

namespace Agiil.Web.TestBuild
{
  public class DataModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .Register(ctx => InMemoryDatabase.Current.GetDataStore())
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
