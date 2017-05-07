using System;
using Agiil.Tests.Tickets;
using Autofac;

namespace Agiil.Tests.Bootstrap
{
  public class TicketsModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<NewTicketController>()
        .As<INewTicketController>();
      
      builder
        .RegisterType<TicketQueryController>()
        .As<ITicketQueryController>();

      builder
        .RegisterType<BulkTicketCreator>()
        .As<IBulkTicketCreator>();
    }
  }
}
