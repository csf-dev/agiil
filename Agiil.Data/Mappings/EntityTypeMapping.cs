using System;
using CSF.Entities;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data.Mappings
{
  public class EntityTypeMapping : IMapping
  {
    readonly IDbNameFormatter formatter;

    public void ApplyMapping(ConventionModelMapper mapper)
    {
      mapper.IsEntity((type, declared) => MappingProvider.BaseEntityType.IsAssignableFrom(type)
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
