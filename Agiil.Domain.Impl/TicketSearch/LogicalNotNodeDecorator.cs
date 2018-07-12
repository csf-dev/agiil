using System;
using Agiil.Domain.Tickets;
using CSF.Data.Specifications;

namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// Indicates that the decorated (inner) node's criterion should be be negated (a logical NOT).
  /// </summary>
  public class LogicalNotNodeDecorator : NodeDecorator, IGetsTicketSpecification
  {
    public ISpecificationExpression<Ticket> GetSpecification()
    {
      var specProvider = DecoratedNode as IGetsTicketSpecification;
      return specProvider.GetSpecification()?.Negate();
    }

    public LogicalNotNodeDecorator(IHasReplacableParent decoratedNode) : base(decoratedNode) {}
  }
}
