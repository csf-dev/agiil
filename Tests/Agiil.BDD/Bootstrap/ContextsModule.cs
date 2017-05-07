using System;
using Agiil.Tests.Tickets;
using Autofac;

namespace Agiil.BDD.Bootstrap
{
  public class ContextsModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<TicketListModelContext>()
        .InstancePerLifetimeScope();
    }
  }
}
