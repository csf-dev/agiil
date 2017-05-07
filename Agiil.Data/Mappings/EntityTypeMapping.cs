using System;
using CSF.Entities;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data.Mappings
{
  public class EntityTypeMapping : IMapping
  {
    public void ApplyMapping(ConventionModelMapper mapper)
    {
      mapper.IsEntity((type, declared) => MappingProvider.BaseEntityType.IsAssignableFrom(type)
                      && type.IsClass);
    }
  }
}
