using System;
using System.Collections.Generic;
using Agiil.Domain.Tickets;
using CSF.Data.Specifications;

namespace Agiil.Domain.TicketSearch
{
  public abstract class NodeDecorator : ISearchNode, IHasReplacableParent
  {
    readonly IHasReplacableParent decoratedNode;

    public virtual ISearchNode DecoratedNode => decoratedNode;

    public virtual IHasChildNodes Parent => decoratedNode.Parent;

    public virtual ISpecificationExpression<Ticket> GetSpecification() => decoratedNode.GetSpecification();

    protected virtual void ReplaceParent(IHasChildNodes replacement) => decoratedNode.ReplaceParent(replacement);

    void IHasReplacableParent.ReplaceParent(IHasChildNodes parent) => ReplaceParent(parent);

    protected NodeDecorator(IHasReplacableParent decoratedNode)
    {
      if(decoratedNode == null)
        throw new ArgumentNullException(nameof(decoratedNode));
      
      this.decoratedNode = decoratedNode;
    }
  }
}
