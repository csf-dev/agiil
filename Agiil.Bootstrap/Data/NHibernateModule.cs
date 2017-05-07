using System;
using Agiil.Data;
using Agiil.Domain;
using Autofac;
using NHibernate;
using NHibernate.Cfg;

namespace Agiil.Bootstrap.Data
{
  public class NHibernateModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      // Configuration
      builder
        .Register((ctx, parameters) => {
          var factory = ctx.Resolve<ISessionFactoryFactory>();
          return factory.GetConfiguration();
        })
        .SingleInstance();

      // ISessionFactory
      builder
        .Register((ctx, parameters) => {
          var config = ctx.Resolve<Configuration>();
          return config.BuildSessionFactory();
        })
        .SingleInstance();

      // ISession
      builder
        .Register((ctx, parameters) => {
          var factory = ctx.Resolve<ISessionFactory>();
          return factory.OpenSession();
        })
        .InstancePerMatchingLifetimeScope(ComponentScope.ApplicationConnection);
    }
  }
}
