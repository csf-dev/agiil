using System;
using Autofac;
using CSF.Data;

namespace Agiil.Bootstrap.Data
{
  public class QueryModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<InMemoryQuery>().AsSelf().As<IQuery>();
    }
  }
}
