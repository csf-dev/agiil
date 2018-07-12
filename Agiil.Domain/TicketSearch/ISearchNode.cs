using System;

namespace Agiil.Domain.TicketSearch
{
  public interface ISearchNode : IHasChildNodes
  {
    IHasChildNodes Parent { get; }
  }
}
