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
        .AsSelf()
        .As<IQuery>();

      builder
        .RegisterType<NHibernatePersister>()
        .AsSelf()
        .As<IPersister>();

      builder
        .RegisterType<NHibernateSchemaExportingDatabaseCreator>()
        .AsSelf()
        .As<IDatabaseCreator>();

      builder
        .RegisterType<DevelopmentInitialDataCreator>()
        .AsSelf()
        .As<IInitialDataCreator>();

      builder
        .RegisterType<EntityData>()
        .AsSelf()
        .As<IEntityData>();

      builder
        .RegisterType<TransactionCreator>()
        .AsSelf()
        .As<ITransactionCreator>();

      builder
        .RegisterType<HardcodedDatabaseConfiguration>()
        .AsSelf()
        .As<IDatabaseConfiguration>();
    }
  }
}
