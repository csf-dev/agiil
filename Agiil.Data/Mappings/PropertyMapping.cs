using System;
using System.Reflection;
using CSF.Entities;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data.Mappings
{
  public class PropertyMapping : IMapping
  {
    readonly IDbNameFormatter formatter;

    public void ApplyMapping(ConventionModelMapper mapper)
    {
      mapper.IsPersistentProperty((member, declared) => {
        var property = member as PropertyInfo;

        if(property == null || !property.CanRead || !property.CanWrite)
          return false;

        if(IsIdentityProperty(property))
          return false;
        
        if(property.ReflectedType.GetProperty(property.Name, BindingFlags.Instance | BindingFlags.Public) == null)
          return false;

        return true;
      });

      mapper.BeforeMapProperty += (modelInspector, member, propertyCustomizer) => {
        propertyCustomizer.Column(formatter.GetColumnName(member.LocalMember));
      };
    }

    bool IsIdentityProperty(PropertyInfo property)
    {
      return (property.Name == IdentityMapping.IdentityPropertyName
              && property.PropertyType == typeof(long)
              && property.DeclaringType == typeof(Entity<long>));
    }

    public PropertyMapping(IDbNameFormatter formatter)
    {
      if(formatter == null)
        throw new ArgumentNullException(nameof(formatter));
      this.formatter = formatter;
    }
  }
}
