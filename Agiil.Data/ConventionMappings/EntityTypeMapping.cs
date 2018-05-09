using System;
using NHibernate.Mapping.ByCode;
using Agiil.Data.MappingProviders;

namespace Agiil.Data.ConventionMappings
{
  public class EntityTypeMapping : IConventionMapping
  {
    readonly IDbNameFormatter formatter;

    public void ApplyMapping(ConventionModelMapper mapper)
    {
      mapper.IsEntity((type, declared) => AgiilMappingProvider.BaseEntityType.IsAssignableFrom(type)
                      && type.IsClass);

      mapper.BeforeMapClass += (modelInspector, type, classCustomizer) => {
        classCustomizer.Table(formatter.GetTableName(type));
      };
    }

    public EntityTypeMapping(IDbNameFormatter formatter)
    {
      if(formatter == null)
        throw new ArgumentNullException(nameof(formatter));
      this.formatter = formatter;
    }
  }
}
