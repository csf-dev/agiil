using System;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Editing;
using Agiil.Tests.Attributes;
using CSF.Entities;
using NUnit.Framework;

namespace Agiil.Tests.Tickets.Editing
{
  [TestFixture,Parallelizable]
  public class RelationshipRemovingTicketEditorDecoratorTests
  {
    [Test,AutoMoqData]
    public void Edit_can_remove_two_primary_relationships_which_are_unwanted(Ticket ticket,
                                                                             EditTicketRequest request,
                                                                             [HasIdentity] TicketRelationship firstRelationship,
                                                                             [HasIdentity] TicketRelationship secondRelationship,
                                                                             [HasIdentity] TicketRelationship thirdRelationship,
                                                                             RelationshipRemovingTicketEditorDecorator sut)
    {
      // Arrange
      ticket.PrimaryRelationships.Clear();
      ticket.PrimaryRelationships.Add(firstRelationship);
      ticket.PrimaryRelationships.Add(secondRelationship);
      ticket.PrimaryRelationships.Add(thirdRelationship);

      request.RelationshipsToDelete.Clear();
      request.RelationshipsToDelete.Add(new DeleteRelationshipRequest { TicketRelationshipId = firstRelationship.GetIdentity() });
      request.RelationshipsToDelete.Add(new DeleteRelationshipRequest { TicketRelationshipId = secondRelationship.GetIdentity() });

      // Act
      sut.Edit(ticket, request);

      // Assert
      Assert.That(ticket.PrimaryRelationships, Is.EquivalentTo(new [] { thirdRelationship }));
    }

    [Test,AutoMoqData]
    public void Edit_can_remove_two_secondary_relationships_which_are_unwanted(Ticket ticket,
                                                                               EditTicketRequest request,
                                                                               [HasIdentity] TicketRelationship firstRelationship,
                                                                               [HasIdentity] TicketRelationship secondRelationship,
                                                                               [HasIdentity] TicketRelationship thirdRelationship,
                                                                               RelationshipRemovingTicketEditorDecorator sut)
    {
      // Arrange
      ticket.SecondaryRelationships.Clear();
      ticket.SecondaryRelationships.Add(firstRelationship);
      ticket.SecondaryRelationships.Add(secondRelationship);
      ticket.SecondaryRelationships.Add(thirdRelationship);

      request.RelationshipsToDelete.Clear();
      request.RelationshipsToDelete.Add(new DeleteRelationshipRequest { TicketRelationshipId = firstRelationship.GetIdentity() });
      request.RelationshipsToDelete.Add(new DeleteRelationshipRequest { TicketRelationshipId = secondRelationship.GetIdentity() });

      // Act
      sut.Edit(ticket, request);

      // Assert
      Assert.That(ticket.SecondaryRelationships, Is.EquivalentTo(new [] { thirdRelationship }));
    }
  }
}
