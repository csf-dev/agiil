using System;
using Agiil.Domain.Tickets;
using CSF.Data.Specifications;

namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// A search node which indicates that the ticket must be closed.
  /// </summary>
  public class IsClosedNode : SearchNode, IGetsTicketSpecification
  {
    public ISpecificationExpression<Ticket> GetSpecification() => new IsClosed();
  }
}
