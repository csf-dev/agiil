using System;
using Agiil.Domain.Tickets.Specs;

namespace Agiil.Bootstrap.Tickets
{
  public class TicketSpecsModule : NamespaceModule
  {
    protected override string Namespace => typeof(IsOpen).Namespace;
  }
}
