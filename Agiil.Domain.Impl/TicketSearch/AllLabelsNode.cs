using System;
using System.Collections.Generic;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using CSF.Data.Specifications;

namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// A search node indicating that the ticket must be associated with all of the named labels.
  /// </summary>
  public class AllLabelsNode : SearchLeaf
  {
    ICollection<string> labelNames;

    public ICollection<string> LabelNames
    {
      get { return labelNames; }
      set { labelNames = value ?? new List<string>(); }
    }

    public override ISpecificationExpression<Ticket> GetSpecification() => new HasAllLabels(labelNames);
  }
}
