using System;
using System.Collections.Generic;
using System.Linq;
using CSF.Data.Entities;
using CSF.Data.NHibernate;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class AvailableRelationshipProvider : IGetsAvailableRelationships
  {
    readonly IEntityData data;

    public IReadOnlyList<AvailableRelationship> GetAvailableRelationships()
    {
      var nonDirectional = data.Query<NonDirectionalRelationship>().ToFuture();
      var directional = data.Query<DirectionalRelationship>().ToFuture();

      return directional
        .SelectMany(GetAvailableRelationships)
        .Union(nonDirectional.SelectMany(GetAvailableRelationships))
        .ToArray();
    }

    IEnumerable<AvailableRelationship> GetAvailableRelationships(NonDirectionalRelationship relationship)
    {
      return new [] {
        new AvailableRelationship {
          RelationshipIdentity = relationship.GetIdentity(),
          Participant = RelationshipParticipant.Primary,
          Summary = relationship.PrimarySummary,
        },
      };
    }

    IEnumerable<AvailableRelationship> GetAvailableRelationships(DirectionalRelationship relationship)
    {
      return new [] {
        new AvailableRelationship {
          RelationshipIdentity = relationship.GetIdentity(),
          Participant = RelationshipParticipant.Primary,
          Summary = relationship.PrimarySummary,
        },
        new AvailableRelationship {
          RelationshipIdentity = relationship.GetIdentity(),
          Participant = RelationshipParticipant.Secondary,
          Summary = relationship.SecondarySummary,
        },
      };
    }

    public AvailableRelationshipProvider(IEntityData data)
    {
      if(data == null)
        throw new ArgumentNullException(nameof(data));
      this.data = data;
    }
  }
}
