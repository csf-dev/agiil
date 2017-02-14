using System;
using Agiil.Data;
using Autofac;
using NHibernate;
using NHibernate.Cfg;

namespace Agiil.Bootstrap.Data
{
  public class NHibernateModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<SessionFactoryFactory>()
        .As<ISessionFactoryFactory>();

      builder
        .RegisterType<DatabaseCreator>()
        .As<IDatabaseCreator>();

      builder
        .Register((ctx, parameters) => {
          var factory = ctx.Resolve<ISessionFactoryFactory>();
          return factory.GetConfiguration();
        })
        .SingleInstance();

      builder
        .Register((ctx, parameters) => {
          var config = ctx.Resolve<Configuration>();
          return config.BuildSessionFactory();
        })
        .SingleInstance();

      builder
        .Register((ctx, parameters) => {
          var factory = ctx.Resolve<ISessionFactory>();
          return factory.OpenSession();
        })
        .InstancePerLifetimeScope();
    }
  }
}
