using System;
using Agiil.Domain.Tickets;
using Agiil.Tests.Attributes;
using CSF.Data.Entities;
using CSF.Entities;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Tickets
{
  [TestFixture,Parallelizable]
  public class TicketRelationshipFactoryTests
  {
    [Test,AutoMoqData]
    public void CreateTicketRelationship_returns_null_if_relationship_id_is_null(TicketReference ticketReference,
                                                                                 RelationshipParticipant participationType,
                                                                                 TicketRelationshipFactory sut)
    {
      // Act
      var result = sut.CreateTicketRelationship(null, ticketReference, participationType);

      // Assert
      Assert.That(result, Is.Null);
    }

    [Test,AutoMoqData]
    public void CreateTicketRelationship_returns_null_if_related_ticket_ref_is_null(IIdentity<Relationship> relationshipId,
                                                                                    RelationshipParticipant participationType,
                                                                                    TicketRelationshipFactory sut)
    {
      // Act
      var result = sut.CreateTicketRelationship(relationshipId, null, participationType);

      // Assert
      Assert.That(result, Is.Null);
    }

    [Test,AutoMoqData]
    public void CreateTicketRelationship_returns_null_if_participant_is_undefined_value(IIdentity<Relationship> relationshipId,
                                                                                        TicketReference ticketReference,
                                                                                        TicketRelationshipFactory sut)
    {
      // Act
      var result = sut.CreateTicketRelationship(relationshipId, ticketReference, (RelationshipParticipant) (-100));

      // Assert
      Assert.That(result, Is.Null);
    }

    [Test,AutoMoqData]
    public void CreateTicketRelationship_sets_up_relationship([Frozen,InMemory] IEntityData data,
                                                              Relationship relationship,
                                                              TicketReference ticketReference,
                                                              RelationshipParticipant participationType,
                                                              TicketRelationshipFactory sut)
    {
      // Arrange
      data.Add(relationship);

      // Act
      var result = sut.CreateTicketRelationship(relationship.GetIdentity(), ticketReference, participationType);

      // Assert
      Assert.That(result?.Relationship, Is.SameAs(relationship));
    }

    [Test,AutoMoqData]
    public void CreateTicketRelationship_sets_up_secondary_ticket_when_participation_is_primary([Frozen] IGetsTicketByReference refQuery,
                                                                                                IIdentity<Relationship> relationshipId,
                                                                                                TicketReference ticketReference,
                                                                                                Ticket relatedTicket,
                                                                                                TicketRelationshipFactory sut)
    {
      // Arrange
      Mock.Get(refQuery).Setup(x => x.GetTicketByReference(ticketReference)).Returns(relatedTicket);

      // Act
      var result = sut.CreateTicketRelationship(relationshipId, ticketReference, RelationshipParticipant.Primary);

      // Assert
      Assert.That(result?.SecondaryTicket, Is.SameAs(relatedTicket));
    }

    [Test,AutoMoqData]
    public void CreateTicketRelationship_sets_up_primary_ticket_when_participation_is_secondary([Frozen] IGetsTicketByReference refQuery,
                                                                                                IIdentity<Relationship> relationshipId,
                                                                                                TicketReference ticketReference,
                                                                                                Ticket relatedTicket,
                                                                                                TicketRelationshipFactory sut)
    {
      // Arrange
      Mock.Get(refQuery).Setup(x => x.GetTicketByReference(ticketReference)).Returns(relatedTicket);

      // Act
      var result = sut.CreateTicketRelationship(relationshipId, ticketReference, RelationshipParticipant.Secondary);

      // Assert
      Assert.That(result?.PrimaryTicket, Is.SameAs(relatedTicket));
    }

    [Test,AutoMoqData]
    public void CreateTicketRelationship_leaves_primary_ticket_unset_when_participation_is_primary([Frozen] IGetsTicketByReference refQuery,
                                                                                                   IIdentity<Relationship> relationshipId,
                                                                                                   TicketReference ticketReference,
                                                                                                   Ticket relatedTicket,
                                                                                                   TicketRelationshipFactory sut)
    {
      // Arrange
      Mock.Get(refQuery).Setup(x => x.GetTicketByReference(ticketReference)).Returns(relatedTicket);

      // Act
      var result = sut.CreateTicketRelationship(relationshipId, ticketReference, RelationshipParticipant.Primary);

      // Assert
      Assert.That(result.PrimaryTicket, Is.Null);
    }

    [Test,AutoMoqData]
    public void CreateTicketRelationship_leaves_secondary_ticket_unset_when_participation_is_secondary([Frozen] IGetsTicketByReference refQuery,
                                                                                                       IIdentity<Relationship> relationshipId,
                                                                                                       TicketReference ticketReference,
                                                                                                       Ticket relatedTicket,
                                                                                                       TicketRelationshipFactory sut)
    {
      // Arrange
      Mock.Get(refQuery).Setup(x => x.GetTicketByReference(ticketReference)).Returns(relatedTicket);

      // Act
      var result = sut.CreateTicketRelationship(relationshipId, ticketReference, RelationshipParticipant.Secondary);

      // Assert
      Assert.That(result.SecondaryTicket, Is.Null);
    }
  }
}
