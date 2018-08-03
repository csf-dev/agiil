using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  [BaseType(typeof(Relationship))]
  public class DirectionalRelationship : Relationship
  {
    public virtual string SecondarySummary { get; set; }

    public DirectionalRelationship() : base(RelationshipType.Directional) {}
  }
}
