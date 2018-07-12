using System;
using System.Collections.Generic;

namespace Agiil.Domain.TicketSearch
{
  public abstract class NodeDecorator : ISearchNode, IHasReplacableParent
  {
    readonly IHasReplacableParent decoratedNode;

    public virtual ISearchNode DecoratedNode => decoratedNode;

    public virtual IHasChildNodes Parent => decoratedNode.Parent;

    public virtual IList<ISearchNode> Children
    {
      get { return decoratedNode.Children; }
      set { decoratedNode.Children = value; }
    }

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
