using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  [BaseType(typeof(Relationship))]
  public class NonDirectionalRelationship : Relationship
  {
    public NonDirectionalRelationship() : base(RelationshipType.NonDirectional) {}
  }
}
