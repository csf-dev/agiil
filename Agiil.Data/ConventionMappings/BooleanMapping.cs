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
        if(ReferenceEquals(prop, null))
          return;

        if(prop.PropertyType == typeof(bool))
          ConfigureBooleanColumn(propertyCustomizer);

        if(prop.PropertyType == typeof(bool?))
          ConfigureNullableBooleanColumn(propertyCustomizer);
      };
    }

    void ConfigureBooleanColumn(IPropertyMapper customizer)
    {
      customizer.NotNullable(true);
      customizer.Column(c => c.Default(false));
    }

    void ConfigureNullableBooleanColumn(IPropertyMapper customizer)
    {
      customizer.NotNullable(false);
      customizer.Column(c => c.Default((bool?) null));
    }
  }
}
