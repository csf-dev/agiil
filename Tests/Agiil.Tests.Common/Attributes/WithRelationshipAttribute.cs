﻿using System;
using System.Reflection;
using Agiil.Domain.Tickets;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.NUnit3;

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

      relationship.SetIdentityValue(relationshipId);

      return new TicketRelationship { Relationship = relationship };
    }
  }
}