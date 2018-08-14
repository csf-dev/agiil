using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Bootstrap.Specifications;
using CSF.Data.Specifications;

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

    ISpecification<Type> GetConcreteTypesSpec()
      => new IsConcreteSpecification().And(new IsOpenGenericSpecification().Negate());
  }
}
