using System;
using Agiil.Domain.Tickets;
using Autofac;

namespace Agiil.Bootstrap.Tickets
{
  public class TicketsModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<TicketFactory>().As<ITicketFactory>();
      builder.RegisterType<TicketCreator>().As<ITicketCreator>();
      builder.RegisterType<CreateTicketValidatorFactory>().As<ICreateTicketValidatorFactory>();
    }
  }
}
