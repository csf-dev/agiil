using System;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using CSF.Data.Specifications;

namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// A search node indicating that the ticket must not be associated with any sprint.
  /// </summary>
  public class HasNoSprintNode : SearchLeaf
  {
    public override ISpecificationExpression<Ticket> GetSpecification() => new HasNoSprint();
  }
}
