using System;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Bootstrap.Specifications
{
  public class ImplementsSpecification<T> : ISpecificationExpression<Type> where T : class
  {
    public Expression<Func<Type, bool>> GetExpression() => type => typeof(T).IsAssignableFrom(type);
  }
}
