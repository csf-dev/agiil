using System;
using System.Collections.Generic;
using System.Linq;
using CSF.Data.Entities;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class AvailableRelationshipProvider : IGetsAvailableRelationships
  {
    readonly IEntityData data;

    public IReadOnlyList<AvailableRelationship> GetAvailableRelationships()
    {
      return data.Query<Relationship>()
                 .SelectMany(GetAvailableRelationships)
                 .ToArray();
    }

    IEnumerable<AvailableRelationship> GetAvailableRelationships(Relationship relationship)
    {
      if(relationship == null) return Enumerable.Empty<AvailableRelationship>();

      if(relationship.Type == RelationshipType.NonDirectional)
        return GetAvailableRelationships((NonDirectionalRelationship) relationship);

      if(relationship.Type == RelationshipType.Directional)
        return GetAvailableRelationships((DirectionalRelationship) relationship);

      return Enumerable.Empty<AvailableRelationship>();
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
