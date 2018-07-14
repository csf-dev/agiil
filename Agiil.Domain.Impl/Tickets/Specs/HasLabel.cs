using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CSF.Data.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
  public class HasLabel : SpecificationExpression<Ticket>
  {
    readonly IEnumerable<string> labelNames;

    public override Expression<Func<Ticket, bool>> GetExpression()
      => ticket => ticket.Labels.Any(label => labelNames.Contains(label.Name));

    public HasLabel(string labelName) : this(new [] {labelName}) {}

    public HasLabel(IEnumerable<string> labelNames)
    {
      if(labelNames == null)
        throw new ArgumentNullException(nameof(labelNames));
      
      this.labelNames = labelNames;
    }
  }
}
