using System;
using Autofac;
using NHibernate;

namespace Agiil.Web.Bootstrap
{
  public class DataModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      // Overrides the registration for ISession.  This module will be loaded after the one from the parent app.
      // This scopes the ISession to the request lifetime scope.
      builder
        .Register((ctx, parameters) => {
          var factory = ctx.Resolve<ISessionFactory>();
          return factory.OpenSession();
        })
        .InstancePerRequest();
    }
  }
}
