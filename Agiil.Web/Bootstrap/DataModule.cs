using System;
using Autofac;
using NHibernate;

namespace Agiil.Web.Bootstrap
{
  public class DataModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .Register(ctx => ctx.Resolve<ISessionFactory>().OpenSession())
        .InstancePerRequest();
    }
  }
}
