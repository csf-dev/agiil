using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
  public class HasAllLabels : ISpecificationExpression<Ticket>
  {
    readonly string[] labelNames;

    public IReadOnlyList<string> LabelNames => labelNames;

    public Expression<Func<Ticket, bool>> GetExpression()
    {
      ISpecificationExpression<Ticket> output = Spec.Expr<Ticket>(x => true);

      foreach(var labelName in labelNames)
      {
        var nameExpression = Spec.Expr<Ticket>(x => x.Labels.Any(l => l.Name == labelName));
        output = output.And(nameExpression);
      }

      return output.GetExpression();
    }

    public HasAllLabels(string labelName) : this(new [] {labelName}) {}

    public HasAllLabels(params string[] labelNames) : this((IEnumerable<string>) labelNames) {}

    public HasAllLabels(IEnumerable<string> labelNames)
    {
      if(labelNames == null)
        throw new ArgumentNullException(nameof(labelNames));

      this.labelNames = labelNames.ToArray();
    }
  }
}
