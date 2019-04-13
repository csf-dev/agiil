using System;
using System.Reflection;
using Agiil.Data.MappingProviders;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data.ConventionMappings
{
  public class BooleanMapping : IConventionMapping
  {
    public void ApplyMapping(ConventionModelMapper mapper)
    {
      mapper.BeforeMapProperty += (modelInspector, member, propertyCustomizer) => {
        var prop = member.LocalMember as PropertyInfo;
        if(ReferenceEquals(prop, null)) return;

        // Actual column nullability is handled in NullableMapping

        if(prop.PropertyType == typeof(bool))
          propertyCustomizer.Column(c => c.Default(false));

        if(prop.PropertyType == typeof(bool?))
          propertyCustomizer.Column(c => c.Default(null));
      };
    }
  }
}
