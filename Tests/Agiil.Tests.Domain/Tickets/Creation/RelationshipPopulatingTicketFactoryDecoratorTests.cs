﻿using System;
using System.Collections.Generic;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Creation;
using Agiil.Tests.Attributes;
using CSF.Entities;
using Moq;
using NUnit.Framework;
using AutoFixture.NUnit3;

namespace Agiil.Tests.Tickets.Creation
{
  [TestFixture,Parallelizable]
  public class RelationshipPopulatingTicketFactoryDecoratorTests
  {
    [Test,AutoMoqData]
    public void CreateTicket_adds_relationships_with_null_primary_ticket_as_primary_relationships([Frozen,CreatesATicket] ICreatesTicket wrappedInstance,
                                                                                                  [Frozen] IConvertsAddRelationshipRequestsToTicketRelationships relationshipFactory,
                                                                                                  TicketRelationship relationship,
                                                                                                  Ticket relatedTicket,
                                                                                                  CreateTicketRequest request,
                                                                                                  AddRelationshipRequest relationshipRequest,
                                                                                                  RelationshipPopulatingTicketFactoryDecorator sut)
    {
      // Arrange
      request.RelationshipsToAdd.Add(relationshipRequest);
      Mock.Get(relationshipFactory)
          .Setup(x => x.Convert(It.IsAny<IEnumerable<AddRelationshipRequest>>()))
          .Returns(new [] { relationship });
      relationship.PrimaryTicket = null;
      relationship.SecondaryTicket = relatedTicket;

      // Act
      var result = sut.CreateTicket(request);

      // Assert
      Assert.That(result?.PrimaryRelationships, Contains.Item(relationship));
      Assert.That(result?.SecondaryRelationships, Does.Not.Contains(relationship));
    }

    [Test,AutoMoqData]
    public void CreateTicket_adds_relationships_with_null_secondary_ticket_as_secondary_relationships([Frozen,CreatesATicket] ICreatesTicket wrappedInstance,
                                                                                                      [Frozen] IConvertsAddRelationshipRequestsToTicketRelationships relationshipFactory,
                                                                                                      TicketRelationship relationship,
                                                                                                      Ticket relatedTicket,
                                                                                                      CreateTicketRequest request,
                                                                                                      AddRelationshipRequest relationshipRequest,
                                                                                                      RelationshipPopulatingTicketFactoryDecorator sut)
    {
      // Arrange
      request.RelationshipsToAdd.Add(relationshipRequest);
      Mock.Get(relationshipFactory)
          .Setup(x => x.Convert(It.IsAny<IEnumerable<AddRelationshipRequest>>()))
          .Returns(new [] { relationship });
      relationship.PrimaryTicket = relatedTicket;
      relationship.SecondaryTicket = null;

      // Act
      var result = sut.CreateTicket(request);

      // Assert
      Assert.That(result?.PrimaryRelationships, Does.Not.Contains(relationship));
      Assert.That(result?.SecondaryRelationships, Contains.Item(relationship));
    }
  }
}
