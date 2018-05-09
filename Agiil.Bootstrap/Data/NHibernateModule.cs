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
      builder
        .RegisterType<SessionFactoryFactory>()
        .As<ISessionFactoryFactory>();

      builder
        .RegisterType<ConfigurationManagerConnectionStringProvider>()
        .As<IConnectionStringProvider>();

      builder
        .Register(BuildNHibernateConfiguration)
        .SingleInstance();

      builder
        .Register(BuildSessionFactory)
        .SingleInstance();

      builder
        .Register(BuildSession)
        .InstancePerMatchingLifetimeScope(ComponentScope.ApplicationConnection);
    }

    Configuration BuildNHibernateConfiguration(IComponentContext ctx)
    {
      var factory = ctx.Resolve<ISessionFactoryFactory>();
      return factory.GetConfiguration();
    }

    ISessionFactory BuildSessionFactory(IComponentContext ctx)
    {
      var config = ctx.Resolve<Configuration>();
      return config.BuildSessionFactory();
    }

    ISession BuildSession(IComponentContext ctx)
    {
      var factory = ctx.Resolve<ISessionFactory>();
      return factory.OpenSession();
    }
  }
}
