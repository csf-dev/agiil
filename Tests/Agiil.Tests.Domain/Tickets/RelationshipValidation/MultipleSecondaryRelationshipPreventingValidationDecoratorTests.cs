using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.RelationshipValidation;
using Agiil.Tests.Attributes;
using CSF.Entities;
using Moq;
using NUnit.Framework;
using AutoFixture.NUnit3;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agiil.Tests.Tickets.RelationshipValidation
{
  [TestFixture,Parallelizable]
  public class MultipleSecondaryRelationshipPreventingValidationDecoratorTests
  {
    [Test, AutoMoqData]
    public void AreRelationshipsValid_returns_false_when_there_are_disallowed_relationships([HasIdentity] Ticket ticket,
                                                                                            [HasIdentity] DirectionalRelationship rel,
                                                                                            [Frozen] IValidatesTheoreticalTicketRelationships wrapped,
                                                                                            MultipleSecondaryRelationshipPreventingValidationDecorator sut)
    {
      var identity = ticket.GetIdentity();
      rel.Behaviour.ProhibitMultipleSecondaryRelationships = true;

      var relationships = new[] {
        new TheoreticalRelationship {
          SecondaryTicket = identity,
          Relationship = rel,
          Type = TheoreticalRelationshipType.Existing,
        },
        new TheoreticalRelationship {
          SecondaryTicket = identity,
          Relationship = rel,
          Type = TheoreticalRelationshipType.Added,
        },
      };

      Mock.Get(wrapped)
        .Setup(x => x.AreRelationshipsValid(It.IsAny<IIdentity<Ticket>>(), It.IsAny<IEnumerable<TheoreticalRelationship>>()))
        .Returns(true);

      var result = sut.AreRelationshipsValid(identity, relationships);

      Assert.That(result, Is.False);
    }

    [Test, AutoMoqData]
    public void AreRelationshipsValid_does_not_consider_removed_relationships_for_validation([HasIdentity] Ticket ticket,
                                                                                             [HasIdentity] DirectionalRelationship rel,
                                                                                             [Frozen] IValidatesTheoreticalTicketRelationships wrapped,
                                                                                             MultipleSecondaryRelationshipPreventingValidationDecorator sut)
    {
      var identity = ticket.GetIdentity();
      rel.Behaviour.ProhibitMultipleSecondaryRelationships = true;

      var relationships = new[] {
        new TheoreticalRelationship {
          SecondaryTicket = identity,
          Relationship = rel,
          Type = TheoreticalRelationshipType.Existing,
        },
        new TheoreticalRelationship {
          SecondaryTicket = identity,
          Relationship = rel,
          Type = TheoreticalRelationshipType.Removed,
        },
      };

      Mock.Get(wrapped)
        .Setup(x => x.AreRelationshipsValid(It.IsAny<IIdentity<Ticket>>(), It.IsAny<IEnumerable<TheoreticalRelationship>>()))
        .Returns(true);

      var result = sut.AreRelationshipsValid(identity, relationships);

      Assert.That(result, Is.True);
    }

    [Test, AutoMoqData]
    public void AreRelationshipsValid_does_not_consider_relationships_of_different_types_for_validation([HasIdentity] Ticket ticket,
                                                                                                        [HasIdentity] DirectionalRelationship rel1,
                                                                                                        [HasIdentity] DirectionalRelationship rel2,
                                                                                                        [Frozen] IValidatesTheoreticalTicketRelationships wrapped,
                                                                                                        MultipleSecondaryRelationshipPreventingValidationDecorator sut)
    {
      var identity = ticket.GetIdentity();
      rel1.Behaviour.ProhibitMultipleSecondaryRelationships = true;
      rel2.Behaviour.ProhibitMultipleSecondaryRelationships = true;

      var relationships = new[] {
        new TheoreticalRelationship {
          SecondaryTicket = identity,
          Relationship = rel1,
          Type = TheoreticalRelationshipType.Existing,
        },
        new TheoreticalRelationship {
          SecondaryTicket = identity,
          Relationship = rel2,
          Type = TheoreticalRelationshipType.Added,
        },
      };

      Mock.Get(wrapped)
        .Setup(x => x.AreRelationshipsValid(It.IsAny<IIdentity<Ticket>>(), It.IsAny<IEnumerable<TheoreticalRelationship>>()))
        .Returns(true);

      var result = sut.AreRelationshipsValid(identity, relationships);

      Assert.That(result, Is.True);
    }

    [Test, AutoMoqData]
    public void AreRelationshipsValid_does_not_consider_relationships_which_permit_duplicates_for_validation([HasIdentity] Ticket ticket,
                                                                                                             [HasIdentity] DirectionalRelationship rel1,
                                                                                                             [Frozen] IValidatesTheoreticalTicketRelationships wrapped,
                                                                                                             MultipleSecondaryRelationshipPreventingValidationDecorator sut)
    {
      var identity = ticket.GetIdentity();
      rel1.Behaviour.ProhibitMultipleSecondaryRelationships = false;

      var relationships = new[] {
        new TheoreticalRelationship {
          SecondaryTicket = identity,
          Relationship = rel1,
          Type = TheoreticalRelationshipType.Existing,
        },
        new TheoreticalRelationship {
          SecondaryTicket = identity,
          Relationship = rel1,
          Type = TheoreticalRelationshipType.Added,
        },
      };

      Mock.Get(wrapped)
        .Setup(x => x.AreRelationshipsValid(It.IsAny<IIdentity<Ticket>>(), It.IsAny<IEnumerable<TheoreticalRelationship>>()))
        .Returns(true);

      var result = sut.AreRelationshipsValid(identity, relationships);

      Assert.That(result, Is.True);
    }

    [Test, AutoMoqData]
    public void AreRelationshipsValid_returns_result_from_wrapped_if_relationships_are_valid([HasIdentity] Ticket ticket,
                                                                                             [Frozen] IValidatesTheoreticalTicketRelationships wrapped,
                                                                                             MultipleSecondaryRelationshipPreventingValidationDecorator sut)
    {
      var identity = ticket.GetIdentity();

      var relationships = Enumerable.Empty<TheoreticalRelationship>();

      Mock.Get(wrapped)
        .Setup(x => x.AreRelationshipsValid(It.IsAny<IIdentity<Ticket>>(), It.IsAny<IEnumerable<TheoreticalRelationship>>()))
        .Returns(false);

      var result = sut.AreRelationshipsValid(identity, relationships);

      Assert.That(result, Is.False);
    }
  }
}
