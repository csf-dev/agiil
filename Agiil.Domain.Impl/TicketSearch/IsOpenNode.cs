using System;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using CSF.Data.Specifications;

namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// A search node which indicates that the ticket must be open.
  /// </summary>
  public class IsOpenNode : SearchLeaf
  {
    public override ISpecificationExpression<Ticket> GetSpecification() => new IsOpen();
  }
}
