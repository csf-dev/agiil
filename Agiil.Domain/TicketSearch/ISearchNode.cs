using System;

namespace Agiil.Domain.TicketSearch
{
  public interface ISearchNode : IGetsTicketSpecification
  {
    IHasChildNodes Parent { get; }
  }
}
