using System;
using System.Reflection;
using System.Linq.Expressions;
using CSF.Data.Specifications;

namespace Agiil.Bootstrap.Specifications
{
  public class HasAttributeSpecification<T> : SpecificationExpression<Type> where T : Attribute
  {
    public override Expression<Func<Type, bool>> GetExpression()
      => type => type.GetCustomAttribute<T>() != null;
  }
}
