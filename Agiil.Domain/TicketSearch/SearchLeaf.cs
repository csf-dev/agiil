using System;
using Agiil.Domain.Tickets;
using CSF.Data.Specifications;

namespace Agiil.Domain.TicketSearch
{
  public abstract class SearchLeaf : ISearchNode, IHasReplacableParent
  {
    IHasChildNodes parent;

    public IHasChildNodes Parent => parent;

    public abstract ISpecificationExpression<Ticket> GetSpecification();

    void IHasReplacableParent.ReplaceParent(IHasChildNodes parent) => this.parent = parent;
  }
}
