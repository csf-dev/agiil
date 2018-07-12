using System;

namespace Agiil.Domain.TicketSearch
{
  public class SearchNode : ChildNodeProvider, ISearchNode, IHasReplacableParent
  {
    IHasChildNodes parent;

    public IHasChildNodes Parent => parent;

    void IHasReplacableParent.ReplaceParent(IHasChildNodes parent) => this.parent = parent;
  }
}
