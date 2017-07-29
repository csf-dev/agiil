using System;
using System.Reflection;
using Agiil.Tests;
using Autofac;
using NHibernate;

namespace Agiil.BDD
{
  public class BddContainerBuilderFactory : WebAppTestingContainerFactory
  {
    public override ContainerBuilder GetContainerBuilder()
    {
      var builder = base.GetContainerBuilder();

      RegisterBddComponents(builder);

      RegisterOverriddenScopeComponents(builder);

      return builder;
    }

    protected virtual void RegisterBddComponents(ContainerBuilder builder)
    {
      builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
    }

    protected virtual void RegisterOverriddenScopeComponents(ContainerBuilder builder)
    {
      // ISession
      builder
        .Register((ctx, parameters) => {
          var factory = ctx.Resolve<ISessionFactory>();
          return factory.OpenSession();
        })
        .InstancePerLifetimeScope();
    }
  }
}
