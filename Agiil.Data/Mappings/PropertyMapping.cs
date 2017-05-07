using System;
using System.Reflection;
using CSF.Entities;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data.Mappings
{
  public class PropertyMapping : IMapping
  {
    public void ApplyMapping(ConventionModelMapper mapper)
    {
      mapper.IsPersistentProperty((member, declared) => {
        var property = member as PropertyInfo;

        if(property == null || !property.CanRead || !property.CanWrite)
        {
          return false;
        }

        if(IsIdentityProperty(property))
        {
          return false;
        }

        return true;
      });
    }

    bool IsIdentityProperty(PropertyInfo property)
    {
      return (property.Name == IdentityMapping.IdentityPropertyName
              && property.PropertyType == typeof(long)
              && property.DeclaringType == typeof(Entity<long>));
    }
  }
}
