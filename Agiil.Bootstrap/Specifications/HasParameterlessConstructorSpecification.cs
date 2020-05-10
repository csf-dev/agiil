using System;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Bootstrap.Specifications
{
  public class HasParameterlessConstructorSpecification : ISpecificationExpression<Type>
  {
    public Expression<Func<Type, bool>> GetExpression()
      => type => type.GetConstructor(Type.EmptyTypes) != null;
  }
}
