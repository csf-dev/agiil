using System;
namespace Agiil.Domain.TicketSearch
{
  public interface IHasReplacableParent : ISearchNode
  {
    void ReplaceParent(IHasChildNodes parent);
  }
}
