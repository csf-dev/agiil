using System;
using System.Reflection;
using Agiil.Domain.Tickets;
using CSF.Entities;
using AutoFixture;
using AutoFixture.NUnit3;

namespace Agiil.Tests.Attributes
{
  public class WithRelationshipAttribute : CustomizeAttribute
  {
    public override ICustomization GetCustomization(ParameterInfo parameter)
    {
      return new WithRelationshipCustomization();
    }
  }

  public class WithRelationshipCustomization : ICustomization
  {
    public void Customize(IFixture fixture)
    {
      fixture.Customize<TicketRelationship>(c => {
        return c
          .FromFactory<RelationshipType,long>(GetTicketRelationship)
          .Without(x => x.Relationship);
      });
    }

    TicketRelationship GetTicketRelationship(RelationshipType t, long relationshipId)
    {
      Relationship relationship = null;

      switch(t)
      {
      case RelationshipType.Directional:
        relationship = new DirectionalRelationship();
        break;

      case RelationshipType.NonDirectional:
        relationship = new NonDirectionalRelationship();
        break;

      }

      ((IEntity) relationship).IdentityValue = relationshipId;

      return new TicketRelationship { Relationship = relationship };
    }
  }
}
