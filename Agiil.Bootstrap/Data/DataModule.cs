using System;
using Agiil.Data;
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
        .RegisterGeneric(typeof(GenericRepository<>))
        .As(typeof(IRepository<>));
      
      builder
        .RegisterType<TransactionCreator>()
        .As<ITransactionCreator>();
    }
  }
}
