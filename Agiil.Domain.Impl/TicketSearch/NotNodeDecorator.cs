using System;
namespace Agiil.Domain.TicketSearch
{
  public class NotNodeDecorator : NodeDecorator
  {
    public NotNodeDecorator(IHasReplacableParent decoratedNode) : base(decoratedNode) {}
  }
}
