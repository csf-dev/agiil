using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class DirectionalRelationship : Relationship
  {
    public virtual string SecondarySummary { get; set; }

    public override void Accept(IVisitsRelationship visitor) => visitor?.Visit(this);

    public DirectionalRelationship() : base(RelationshipType.Directional) {}
  }
}
