using System;
using Agiil.Data.MappingProviders;
using Agiil.Domain.Labels;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data.ClassMappings
{
  public class LabelMapping : IConventionMapping
  {
    readonly IDbNameFormatter nameFormatter;

    public void ApplyMapping(ConventionModelMapper mapper)
    {
      mapper.Class<Label>(map => {
        map.Property(x => x.Name, mapping => {
          mapping.Unique(true);
          mapping.Index(nameFormatter.GetUniqueIndexName<Label>(l => l.Name));
        });
      });
    }

    public LabelMapping(IDbNameFormatter nameFormatter)
    {
      if(nameFormatter == null)
        throw new ArgumentNullException(nameof(nameFormatter));
      this.nameFormatter = nameFormatter;
    }
  }
}
