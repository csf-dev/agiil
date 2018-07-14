using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CSF.Data.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
  public class HasAllLabels : SpecificationExpression<Ticket>
  {
    readonly IEnumerable<string> labelNames;

    public override Expression<Func<Ticket, bool>> GetExpression()
      => ticket => labelNames.All(name => ticket.Labels.Any(label => label.Name == name));

    public HasAllLabels(string labelName) : this(new [] {labelName}) {}

    public HasAllLabels(IEnumerable<string> labelNames)
    {
      if(labelNames == null)
        throw new ArgumentNullException(nameof(labelNames));

      this.labelNames = labelNames;
    }
  }
}
