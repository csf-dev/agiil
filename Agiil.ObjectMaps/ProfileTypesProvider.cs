using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using AutoMapper;

namespace Agiil.ObjectMaps
{
  public class ProfileTypesProvider : IProfileTypesProvider
  {
    protected static readonly Type ProfileBaseType = typeof(Profile);

    public virtual IEnumerable<Type> GetAllProfileTypes()
    {
      var assembliesToScan = GetProfileAssemblies();

      var output = (from assembly in assembliesToScan
                    from type in assembly.GetExportedTypes()
                    where
                      type.IsClass
                      && !type.IsAbstract
                      && ProfileBaseType.IsAssignableFrom(type)
                    select type)
        .ToArray();

      return output;
    }

    protected virtual IEnumerable<Assembly> GetProfileAssemblies()
    {
      return new [] {
        Assembly.GetAssembly(typeof(IMapperConfigurationFactory)),
      };
    }
  }
}
