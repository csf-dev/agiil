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
      mapper.IsRootEntity((type, declared) => type.BaseType == null
                          || IsEntityBaseType(type.BaseType));
    }

    bool IsEntityBaseType(Type type)
    {
      var result = ((type.IsGenericType
                     && type.GetGenericTypeDefinition() == typeof(Entity<>))
                    || (type.IsGenericTypeDefinition
                        && type == typeof(Entity<>)));

      return result;
    }
  }
}
