using System;
using Agiil.Domain.Tickets;

namespace Agiil.Domain.TicketSearch
{
  public interface ISearchNode : IGetsTicketSpecification
  {
    IHasChildNodes Parent { get; }
  }
}
