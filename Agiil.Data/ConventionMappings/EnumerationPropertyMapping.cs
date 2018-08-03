using System;
using System.Reflection;
using Agiil.Data.MappingProviders;
using NHibernate.Mapping.ByCode;
using NHibernate.Type;

namespace Agiil.Data.ConventionMappings
{
  public class EnumerationPropertyMapping : IConventionMapping
  {
    static readonly Type OpenGenericEnumType = typeof(EnumStringType<>);

    public void ApplyMapping(ConventionModelMapper mapper)
    {
      mapper.BeforeMapProperty += (modelInspector, member, propertyCustomizer) => {
        var propertyInfo = member.LocalMember as PropertyInfo;
        if(propertyInfo == null) return;

        if(!propertyInfo.PropertyType.IsEnum) return;

        propertyCustomizer.Type(GetEnumerationType(propertyInfo));
      };
    }

    IType GetEnumerationType(PropertyInfo property)
    {
      var enumType = OpenGenericEnumType.MakeGenericType(property.PropertyType);
      return (IType) Activator.CreateInstance(enumType);
    }
  }
}
