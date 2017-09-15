using System;
using Agiil.Data;
using Agiil.Domain.Data;
using Autofac;
using CSF.Data;
using CSF.Data.Entities;
using CSF.Data.NHibernate;

namespace Agiil.Bootstrap.Data
{
  public class DataModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<NHibernateQuery>()
        .As<IQuery>();

      builder
        .RegisterType<NHibernatePersister>()
        .As<IPersister>();

      builder
        .RegisterType<DatabaseCreator>()
        .As<IDatabaseCreator>();

      builder
        .RegisterType<DevelopmentInitialDataCreator>()
        .As<IInitialDataCreator>();

      builder
        .RegisterType<EntityData>()
        .As<IEntityData>();

      builder
        .RegisterType<TransactionCreator>()
        .As<ITransactionCreator>();

      builder
        .RegisterType<HardcodedDatabaseConfiguration>()
        .As<IDatabaseConfiguration>();
    }
  }
}
