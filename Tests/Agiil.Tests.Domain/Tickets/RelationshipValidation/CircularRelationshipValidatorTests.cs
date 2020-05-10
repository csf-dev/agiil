using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.RelationshipValidation;
using Agiil.Tests.Attributes;
using CSF.Entities;
using Moq;
using NUnit.Framework;
using AutoFixture.NUnit3;
using System;
using System.Collections.Generic;

namespace Agiil.Tests.Tickets.RelationshipValidation
{
  [TestFixture,Parallelizable]
  public class CircularRelationshipValidatorTests
  {
    [Test, AutoMoqData]
    public void AreRelationshipsValid_gets_hierarchical_relationships([Frozen] IGetsHierarchicalTicketRelationshipsWhichCouldCreateACircularRelationship hierarchicalRelationshipProvider,
                                                                      CircularRelationshipValidator sut,
                                                                      IEnumerable<TheoreticalRelationship> relationships,
                                                                      IIdentity<Ticket> editedTicket)
    {
      sut.AreRelationshipsValid(editedTicket, relationships);

      Mock.Get(hierarchicalRelationshipProvider)
        .Verify(x => x.GetRelevantHierarchicalRelationships(relationships), Times.Once);
    }

    [Test, AutoMoqData]
    public void AreRelationshipsValid_passes_hierarchical_relationships_to_traversible_provider([Frozen] IGetsHierarchicalTicketRelationshipsWhichCouldCreateACircularRelationship hierarchicalRelationshipProvider,
                                                                                                [Frozen] IGetsTraversibleRelationships traversibleRelationshipProvider,
                                                                                                CircularRelationshipValidator sut,
                                                                                                IEnumerable<TheoreticalRelationship> relationships,
                                                                                                IIdentity<Ticket> editedTicket,
                                                                                                IEnumerable<HierarchicalTicketRelationship> hierarchicalRelationships)
    {
      Mock.Get(hierarchicalRelationshipProvider)
        .Setup(x => x.GetRelevantHierarchicalRelationships(relationships))
        .Returns(hierarchicalRelationships);

      sut.AreRelationshipsValid(editedTicket, relationships);

      Mock.Get(traversibleRelationshipProvider)
        .Verify(x => x.GetTraversibleRelationships(relationships, hierarchicalRelationships), Times.Once);
    }

    [Test, AutoMoqData]
    public void AreRelationshipsValid_returns_false_if_any_relationship_is_circular([Frozen] IGetsHierarchicalTicketRelationshipsWhichCouldCreateACircularRelationship hierarchicalRelationshipProvider,
                                                                                    [Frozen] IGetsTraversibleRelationships traversibleRelationshipProvider,
                                                                                    [Frozen] IDetectsCircularRelationship detector,
                                                                                    CircularRelationshipValidator sut,
                                                                                    IEnumerable<TheoreticalRelationship> relationships,
                                                                                    IIdentity<Ticket> editedTicket,
                                                                                    IEnumerable<HierarchicalTicketRelationship> hierarchicalRelationships,
                                                                                    TraversibleRelationship traversibleRelationship)
    {
      var allRelationships = new[] { traversibleRelationship };
      Mock.Get(hierarchicalRelationshipProvider)
        .Setup(x => x.GetRelevantHierarchicalRelationships(relationships))
        .Returns(hierarchicalRelationships);
      Mock.Get(traversibleRelationshipProvider)
        .Setup(x => x.GetTraversibleRelationships(relationships, hierarchicalRelationships))
        .Returns(allRelationships);
      Mock.Get(detector)
        .Setup(x => x.IsRelationshipCircular(traversibleRelationship.Type, allRelationships))
        .Returns(true);

      var result = sut.AreRelationshipsValid(editedTicket, relationships);

      Assert.That(result, Is.False);
    }

    [Test, AutoMoqData]
    public void AreRelationshipsValid_returns_true_if_no_relationship_is_circular([Frozen] IGetsHierarchicalTicketRelationshipsWhichCouldCreateACircularRelationship hierarchicalRelationshipProvider,
                                                                                  [Frozen] IGetsTraversibleRelationships traversibleRelationshipProvider,
                                                                                  [Frozen] IDetectsCircularRelationship detector,
                                                                                  CircularRelationshipValidator sut,
                                                                                  IEnumerable<TheoreticalRelationship> relationships,
                                                                                  IIdentity<Ticket> editedTicket,
                                                                                  IEnumerable<HierarchicalTicketRelationship> hierarchicalRelationships,
                                                                                  TraversibleRelationship traversibleRelationship)
    {
      var allRelationships = new[] { traversibleRelationship };
      Mock.Get(hierarchicalRelationshipProvider)
        .Setup(x => x.GetRelevantHierarchicalRelationships(relationships))
        .Returns(hierarchicalRelationships);
      Mock.Get(traversibleRelationshipProvider)
        .Setup(x => x.GetTraversibleRelationships(relationships, hierarchicalRelationships))
        .Returns(allRelationships);
      Mock.Get(detector)
        .Setup(x => x.IsRelationshipCircular(traversibleRelationship.Type, allRelationships))
        .Returns(false);

      var result = sut.AreRelationshipsValid(editedTicket, relationships);

      Assert.That(result, Is.True);
    }
  }
}
