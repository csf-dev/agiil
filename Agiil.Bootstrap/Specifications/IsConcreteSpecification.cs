using System;
using System.Linq.Expressions;
using CSF.Data.Specifications;

namespace Agiil.Bootstrap.Specifications
{
  public class IsConcreteSpecification : SpecificationExpression<Type>
  {
    static readonly Type DelegateType = typeof(MulticastDelegate);

    public override Expression<Func<Type, bool>> GetExpression()
      => type => type.IsClass 
                 && !type.IsAbstract
                 && !DelegateType.IsAssignableFrom(type);
  }
}
