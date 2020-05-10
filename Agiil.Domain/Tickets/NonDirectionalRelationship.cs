using System;

namespace Agiil.Domain.Tickets
{
  public class NonDirectionalRelationship : Relationship
  {
    public override void Accept(IVisitsRelationship visitor) => visitor?.Visit(this);

    public NonDirectionalRelationship() : base(RelationshipType.NonDirectional) {}
  }
}
