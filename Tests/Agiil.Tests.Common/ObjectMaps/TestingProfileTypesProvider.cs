using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Agiil.ObjectMaps;

namespace Agiil.Tests.ObjectMaps
{
  public class TestingProfileTypesProvider : ProfileTypesProvider
  {
    protected override IEnumerable<Assembly> GetProfileAssemblies()
    {
      return base
        .GetProfileAssemblies()
        .Union(new [] { Assembly.GetExecutingAssembly() })
        .ToArray();
    }
  }
}
