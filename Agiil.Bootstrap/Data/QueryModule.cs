using System;
using Autofac;
using CSF.Data;
using CSF.Data.NHibernate;

namespace Agiil.Bootstrap.Data
{
  public class QueryModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<NHibernateQuery>()
        .As<IQuery>();
    }
  }
}
