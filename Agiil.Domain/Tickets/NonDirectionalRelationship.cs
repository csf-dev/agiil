using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  [BaseType(typeof(Relationship))]
  public class NonDirectionalRelationship : Relationship
  {
    public override void Accept(IVisitsRelationship visitor) => visitor?.Visit(this);

    public NonDirectionalRelationship() : base(RelationshipType.NonDirectional) {}
  }
}
