using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Bootstrap.Specifications;
using CSF.Data.Specifications;

namespace Agiil.Bootstrap
{
  public class OpenGenericTypesInAssemblyOfMarkerProvider : IGetsTypes
  {
    public IEnumerable<Type> GetTypes<T>()
    {
      var assembly = typeof(T).Assembly;
      var isOpenGeneric = GetOpenGenericTypeSpec();

      return assembly.GetExportedTypes()
                     .Where(isOpenGeneric)
                     .ToArray();
    }

    ISpecification<Type> GetOpenGenericTypeSpec()
    => new IsConcreteSpecification().And(new IsOpenGenericSpecification());
  }
}
