using System;
using System.Linq.Expressions;
using CSF.Data.Specifications;

namespace Agiil.Bootstrap.Specifications
{
  public class ImplementsSpecification<T> : SpecificationExpression<Type> where T : class
  {
    public override Expression<Func<Type, bool>> GetExpression() => type => typeof(T).IsAssignableFrom(type);
  }
}
