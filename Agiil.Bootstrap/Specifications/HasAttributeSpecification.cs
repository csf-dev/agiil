using System;
using System.Reflection;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Bootstrap.Specifications
{
  public class HasAttributeSpecification<T> : ISpecificationExpression<Type> where T : Attribute
  {
    public Expression<Func<Type, bool>> GetExpression()
      => type => type.GetCustomAttribute<T>() != null;
  }
}
