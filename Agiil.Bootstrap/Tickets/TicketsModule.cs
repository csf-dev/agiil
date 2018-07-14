using System;
using System.Collections.Generic;
using Agiil.Domain.Tickets;
using Autofac;

namespace Agiil.Bootstrap.Tickets
{
  public class TicketsModule : NamespaceModule
  {
    protected override string Namespace => typeof(TicketCreator).Namespace;

    protected override IEnumerable<Type> TypesNotToRegisterAutomatically
    => new [] {
      typeof(TicketQueryProvider),
      typeof(SpecificationQueryProviderDecorator),
    };
	}
}
