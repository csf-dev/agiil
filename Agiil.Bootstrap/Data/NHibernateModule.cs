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

            // It is intentional that I am not registering the way to get an ISession here.
            // The web app wants an ISession per HTTP request, but other things such as integration
            // tests want it "per-an-arbitrary-scope" (since over there, there's no such thing as
            // an HTTP request).
            //
            // So, I leave it to those projects to declare how they want the session.
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
    }
}
