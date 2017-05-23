using System;
using System.Collections.Generic;
using Agiil.Bootstrap;
using Agiil.Tests.Tickets;
using Autofac;

namespace Agiil.Tests.Bootstrap
{
  public class TicketsModule : NamespaceModule
  {
    protected override IEnumerable<System.Reflection.Assembly> GetSearchAssemblies()
    {
      return new [] { System.Reflection.Assembly.GetExecutingAssembly() };
    }

    protected override string Namespace => typeof(IBulkTicketCreator).Namespace;
  }
}
