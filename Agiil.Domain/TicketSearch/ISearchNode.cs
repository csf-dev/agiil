using System;

namespace Agiil.Domain.TicketSearch
{
  public interface ISearchNode : IHasChildNodes, IGetsTicketSpecification
  {
    IHasChildNodes Parent { get; }
  }
}
