using System;
using System.Collections.Generic;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.RelationshipValidation;
using Agiil.Tests.Attributes;
using CSF.Entities;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Tickets.RelationshipValidation
{
  [TestFixture, Parallelizable]
  public class PossiblyCircularHierarchicalTicketRelationshipProviderAdapterTests
  {
    [Test, AutoMoqData]
    public void GetRelevantHierarchicalRelationships_can_get_a_relationship_with_a_primary_ticket_identity(DirectionalRelationship relationship,
                                                                                                           Identity<long,Ticket> ticketId,
                                                                                                           [Frozen] IGetsHierarchicalTicketRelationships relationshipProvider,
                                                                                                           PossiblyCircularHierarchicalTicketRelationshipProviderAdapter sut)
    {
      var theoreticalRelationship = new TheoreticalRelationship {
        Relationship = relationship,
        PrimaryTicket = ticketId
      };
      relationship.Behaviour.ProhibitCircularRelationship = true;

      sut.GetRelevantHierarchicalRelationships(new[] { theoreticalRelationship });

      Mock.Get(relationshipProvider)
        .Verify(x => x.GetRelationships(ticketId), Times.Once);
    }

    [Test, AutoMoqData]
    public void GetRelevantHierarchicalRelationships_can_get_a_relationship_with_a_secondary_ticket_identity(DirectionalRelationship relationship,
                                                                                                             Identity<long, Ticket> ticketId,
                                                                                                             [Frozen] IGetsHierarchicalTicketRelationships relationshipProvider,
                                                                                                             PossiblyCircularHierarchicalTicketRelationshipProviderAdapter sut)
    {
      var theoreticalRelationship = new TheoreticalRelationship {
        Relationship = relationship,
        SecondaryTicket = ticketId
      };
      relationship.Behaviour.ProhibitCircularRelationship = true;

      sut.GetRelevantHierarchicalRelationships(new[] { theoreticalRelationship });

      Mock.Get(relationshipProvider)
        .Verify(x => x.GetRelationships(ticketId), Times.Once);
    }

    [Test, AutoMoqData]
    public void GetRelevantHierarchicalRelationships_returns_result_from_provider([Frozen] IGetsHierarchicalTicketRelationships relationshipProvider,
                                                                                  PossiblyCircularHierarchicalTicketRelationshipProviderAdapter sut,
                                                                                  IEnumerable<HierarchicalTicketRelationship> expected)
    {
      Mock.Get(relationshipProvider)
        .Setup(x => x.GetRelationships(It.IsAny<IIdentity<Ticket>[]>()))
        .Returns(expected);

      var result = sut.GetRelevantHierarchicalRelationships(new TheoreticalRelationship[0]);

      Assert.That(result, Is.SameAs(expected));
    }

    [Test, AutoMoqData]
    public void GetRelevantHierarchicalRelationships_does_not_include_a_nondirectional_relationship(NonDirectionalRelationship relationship,
                                                                                                    Identity<long, Ticket> ticketId,
                                                                                                    [Frozen] IGetsHierarchicalTicketRelationships relationshipProvider,
                                                                                                    PossiblyCircularHierarchicalTicketRelationshipProviderAdapter sut)
    {
      var theoreticalRelationship = new TheoreticalRelationship {
        Relationship = relationship,
        PrimaryTicket = ticketId
      };
      relationship.Behaviour.ProhibitCircularRelationship = true;

      sut.GetRelevantHierarchicalRelationships(new[] { theoreticalRelationship });

      Mock.Get(relationshipProvider)
        .Verify(x => x.GetRelationships(It.Is<IIdentity<Ticket>[]>(p => p.Length == 0)), Times.Once);
    }

    [Test, AutoMoqData]
    public void GetRelevantHierarchicalRelationships_does_not_include_a_relationship_which_permits_circles(DirectionalRelationship relationship,
                                                                                                           Identity<long, Ticket> ticketId,
                                                                                                           [Frozen] IGetsHierarchicalTicketRelationships relationshipProvider,
                                                                                                           PossiblyCircularHierarchicalTicketRelationshipProviderAdapter sut)
    {
      var theoreticalRelationship = new TheoreticalRelationship {
        Relationship = relationship,
        PrimaryTicket = ticketId
      };
      relationship.Behaviour.ProhibitCircularRelationship = false;

      sut.GetRelevantHierarchicalRelationships(new[] { theoreticalRelationship });

      Mock.Get(relationshipProvider)
        .Verify(x => x.GetRelationships(It.Is<IIdentity<Ticket>[]>(p => p.Length == 0)), Times.Once);
    }
  }
}
