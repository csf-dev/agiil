using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CSF.Data.Specifications;

namespace Agiil.Domain.Labels.Specs
{
  public class LabelNameIn : SpecificationExpression<Label>
  {
    readonly IEnumerable<string> names;

    public override Expression<Func<Label, bool>> GetExpression()
      => label => names.Contains(label.Name);

    public LabelNameIn(IEnumerable<string> names)
    {
      if(names == null)
        throw new ArgumentNullException(nameof(names));

      this.names = names;
    }
  }
}
