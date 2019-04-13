using System;
using System.Reflection;
using Agiil.Data.MappingProviders;
using Agiil.Domain;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data.ConventionMappings
{
  public class NullableMapping : IConventionMapping
  {
    public void ApplyMapping(ConventionModelMapper mapper)
    {
      mapper.BeforeMapProperty += (modelInspector, member, propertyCustomizer) => {
        var propertyInfo = member.LocalMember as PropertyInfo;
        if(propertyInfo == null) return;

        var isNullable = IsNullable(propertyInfo);
        propertyCustomizer.NotNullable(!isNullable);
      };

      mapper.BeforeMapManyToOne += (modelInspector, member, propertyCustomizer) => {
        var propertyInfo = member.LocalMember as PropertyInfo;
        if(propertyInfo == null) return;

        var isNullable = IsNullable(propertyInfo);
        propertyCustomizer.NotNullable(!isNullable);
      };
    }

    bool IsNullable(PropertyInfo property)
    {
      if(IsGenericNullable(property.PropertyType)) return true;
      if(property.PropertyType.IsValueType) return false;
      if(property.GetCustomAttribute<AllowNullAttribute>() != null) return true;
      return false;
    }

    bool IsGenericNullable(Type type)
    {
      return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
    }
  }
}
