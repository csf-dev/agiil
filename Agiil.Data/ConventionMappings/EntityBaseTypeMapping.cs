using System;
using CSF.Entities;
using NHibernate.Mapping.ByCode;
using Agiil.Data.MappingProviders;

namespace Agiil.Data.ConventionMappings
{
  public class EntityBaseTypeMapping : IConventionMapping
  {
    public void ApplyMapping(ConventionModelMapper mapper)
    {
      mapper.IsRootEntity(IsRootEntity);
    }

    bool IsRootEntity(Type type, bool isDeclaredAsRootAlready)
    {
      if(type.IsInterface) return false;
      if(type == typeof(object)) return false;
      return AgiilMappingProvider.IsEntityBaseType(type.BaseType);
    }
  }
}
