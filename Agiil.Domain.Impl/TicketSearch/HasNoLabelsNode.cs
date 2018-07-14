using System;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using CSF.Data.Specifications;

namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// A search node indicating that the ticket must have no labels at all.
  /// </summary>
  public class HasNoLabelsNode : SearchNode
  {
    public override ISpecificationExpression<Ticket> GetSpecification() => new HasNoLabels();
  }
}
