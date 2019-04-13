using System;
using Agiil.Data.MappingProviders;
using Agiil.Domain.Tickets;
using CSF.Reflection;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data.ClassMappings
{
  public class RelationshipMapping : IConventionMapping
  {
    readonly IDbNameFormatter nameFormatter;

    public void ApplyMapping(ConventionModelMapper mapper)
    {
      MapRelationship(mapper);
      MapDirectionalRelationship(mapper);
      MapNonDirectionalRelationship(mapper);
    }

    void MapRelationship(ConventionModelMapper mapper)
    {
      mapper.Class<Relationship>(map => {
        map.Discriminator(d => {
          d.Column(nameFormatter.GetColumnName(Reflect.Property<Relationship>(x => x.Type)));
        });
      });
    }

    void MapDirectionalRelationship(ConventionModelMapper mapper)
    {
      mapper.Subclass<DirectionalRelationship>(map => {
        map.DiscriminatorValue(RelationshipType.Directional);

        map.Property(x => x.SecondarySummary, p => {
          p.NotNullable(false);
        });
      });
    }

    void MapNonDirectionalRelationship(ConventionModelMapper mapper)
    {
      mapper.Subclass<NonDirectionalRelationship>(map => {
          map.DiscriminatorValue(RelationshipType.NonDirectional);
      });
    }

    public RelationshipMapping(IDbNameFormatter nameFormatter)
    {
      if(nameFormatter == null)
        throw new ArgumentNullException(nameof(nameFormatter));
      this.nameFormatter = nameFormatter;
    }
  }
}
