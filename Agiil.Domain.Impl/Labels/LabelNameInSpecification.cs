using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CSF.Data.Specifications;

namespace Agiil.Domain.Labels
{
  public class LabelNameInSpecification : SpecificationExpression<Label>
  {
    readonly IReadOnlyCollection<string> names;

    public override Expression<Func<Label, bool>> GetExpression()
      => label => names.Contains(label.Name);

    public LabelNameInSpecification(IReadOnlyCollection<string> names)
    {
      if(names == null)
        throw new ArgumentNullException(nameof(names));

      this.names = names;
    }
  }
}
