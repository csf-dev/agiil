using System;
using System.Collections.Generic;
using CSF.Entities;

namespace Agiil.Domain.Tickets.RelationshipValidation
{
  public interface IDetectsCircularRelationship
  {
    bool IsRelationshipCircular(IIdentity<Relationship> relationshipType, IEnumerable<TraversibleRelationship> allRelationships);
  }
}
