using System;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Bootstrap.Specifications
{
  public class IsOpenGenericSpecification : ISpecificationExpression<Type>
  {
    public Expression<Func<Type, bool>> GetExpression()
      => type => type.IsGenericTypeDefinition;
  }
}
