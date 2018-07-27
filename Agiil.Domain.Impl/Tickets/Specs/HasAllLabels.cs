using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CSF.Data.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
  public class HasAllLabels : SpecificationExpression<Ticket>
  {
    readonly string[] labelNames;

    public IReadOnlyList<string> LabelNames => labelNames;

    public override Expression<Func<Ticket, bool>> GetExpression()
    {
      ISpecificationExpression<Ticket> output = new DynamicSpecificationExpression<Ticket>(x => true);

      foreach(var labelName in labelNames)
      {
        var nameExpression = new DynamicSpecificationExpression<Ticket>(x => x.Labels.Any(l => l.Name == labelName));
        output = output.And(nameExpression);
      }

      return output.GetExpression();
    }

    public HasAllLabels(string labelName) : this(new [] {labelName}) {}

    public HasAllLabels(IEnumerable<string> labelNames)
    {
      if(labelNames == null)
        throw new ArgumentNullException(nameof(labelNames));

      this.labelNames = labelNames.ToArray();
    }
  }
}
