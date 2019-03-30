using System;
using System.Linq.Expressions;
using CSF.Data.Specifications;

namespace Agiil.Bootstrap.Specifications
{
  public class HasParameterlessConstructorSpecification : SpecificationExpression<Type>
  {
    public override Expression<Func<Type, bool>> GetExpression()
      => type => type.GetConstructor(Type.EmptyTypes) != null;
  }
}
