using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Domain.Labels.Specs
{
  public class LabelNameIn : ISpecificationExpression<Label>
  {
    readonly IEnumerable<string> names;

    public Expression<Func<Label, bool>> GetExpression()
      => label => names.Contains(label.Name);

    public LabelNameIn(IEnumerable<string> names)
    {
      if(names == null)
        throw new ArgumentNullException(nameof(names));

      this.names = names;
    }
  }
}
