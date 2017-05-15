using System;
using Agiil.Domain.Tickets;
using Autofac;

namespace Agiil.Bootstrap.Tickets
{
  public class TicketsModule : NamespaceModule
  {
    protected override string Namespace => typeof(TicketCreator).Namespace;
  }
}
