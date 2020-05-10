using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Bootstrap.Specifications;
using CSF.Specifications;

namespace Agiil.Bootstrap
{
  public class ConcreteTypesInAssemblyOfMarkerProvider : IGetsTypes
  {
    public IEnumerable<Type> GetTypes<T>()
    {
      var assembly = typeof(T).Assembly;
      var isConcrete = GetConcreteTypesSpec();

      return assembly.GetExportedTypes()
                     .Where(isConcrete)
                     .ToArray();
    }

    ISpecificationExpression<Type> GetConcreteTypesSpec()
      => new IsConcreteSpecification().And(new IsOpenGenericSpecification().Not());
  }
}
