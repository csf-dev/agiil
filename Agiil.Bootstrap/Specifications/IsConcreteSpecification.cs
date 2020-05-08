using System;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Bootstrap.Specifications
{
  public class IsConcreteSpecification : ISpecificationExpression<Type>
  {
    static readonly Type DelegateType = typeof(MulticastDelegate);

    public Expression<Func<Type, bool>> GetExpression()
      => type => type.IsClass 
                 && !type.IsAbstract
                 && !DelegateType.IsAssignableFrom(type);
  }
}
