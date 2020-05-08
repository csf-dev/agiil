using System;
using System.Reflection;
using CSF.Entities;
using NHibernate.Mapping.ByCode;
using Agiil.Data.MappingProviders;

namespace Agiil.Data.ConventionMappings
{
  public class PropertyMapping : IConventionMapping
  {
    readonly IDbNameFormatter formatter;
    readonly IGetsWhetherPropertyShouldBeMapped ignoredPropertiesProvider;

    public void ApplyMapping(ConventionModelMapper mapper)
    {
      mapper.IsPersistentProperty((member, declared) => {
        var property = member as PropertyInfo;

        if(property == null || !property.CanRead)
          return false;

        if(IsIdentityProperty(property))
          return false;
        
        if(property.ReflectedType.GetProperty(property.Name, BindingFlags.Instance | BindingFlags.Public) == null)
          return false;

        if(!ignoredPropertiesProvider.ShouldMapProperty(property))
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

    public PropertyMapping(IDbNameFormatter formatter,
                           IGetsWhetherPropertyShouldBeMapped ignoredPropertiesProvider)
    {
      this.formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
      this.ignoredPropertiesProvider = ignoredPropertiesProvider ?? throw new ArgumentNullException(nameof(ignoredPropertiesProvider));
    }
  }
}
