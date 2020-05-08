using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
  public class HasLabel : ISpecificationExpression<Ticket>
  {
    readonly string[] labelNames;

    public IReadOnlyList<string> LabelNames => labelNames;

    public Expression<Func<Ticket, bool>> GetExpression()
      => ticket => (from label in ticket.Labels
                    where labelNames.Contains(label.Name)
                    select ticket).Any();

    public HasLabel(string labelName) : this(new [] {labelName}) {}

    public HasLabel(params string[] labelNames) : this((IEnumerable<string>) labelNames) {}

    public HasLabel(IEnumerable<string> labelNames)
    {
      if(labelNames == null)
        throw new ArgumentNullException(nameof(labelNames));
      
      this.labelNames = labelNames.ToArray();
    }
  }
}
