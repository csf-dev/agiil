using System;
using CSF.Entities;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data.Mappings
{
  public class EntityBaseTypeMapping : IMapping
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
