using NUnit.Framework;
using System;
using Agiil.Domain.Tickets.RelationshipValidation;
using Agiil.Tests.Attributes;
using Ploeh.AutoFixture.NUnit3;
using AutoMapper;
using System.Linq;
using Agiil.Domain.Tickets;
using Moq;
using CSF.Entities;

namespace Agiil.Tests.Tickets.RelationshipValidation
{
  [TestFixture,Parallelizable]
  public class TraversibleRelationshipProviderTests
  {
    [Test, AutoMoqData]
    public void GetTraversibleRelationships_returns_mapped_existing_and_added_theoretical_relationships([Frozen] IMapper mapper,
                                                                                                        TheoreticalRelationship rel1,
                                                                                                        TheoreticalRelationship rel2,
                                                                                                        TraversibleRelationship trav1,
                                                                                                        TraversibleRelationship trav2,
                                                                                                        TraversibleRelationshipProvider sut)
    {
      rel1.Type = TheoreticalRelationshipType.Existing;
      rel2.Type = TheoreticalRelationshipType.Added;

      Mock.Get(mapper).Setup(x => x.Map<TraversibleRelationship>(rel1)).Returns(trav1);
      Mock.Get(mapper).Setup(x => x.Map<TraversibleRelationship>(rel2)).Returns(trav2);

      var result = sut.GetTraversibleRelationships(new[] { rel1, rel2 }, Enumerable.Empty<HierarchicalTicketRelationship>());

      Assert.That(result, Is.EquivalentTo(new[] { trav1, trav2 }));
    }

    [Test, AutoMoqData]
    public void GetTraversibleRelationships_does_not_return_removed_theoretical_relationship([Frozen] IMapper mapper,
                                                                                             TheoreticalRelationship rel1,
                                                                                             TraversibleRelationship trav1,
                                                                                             TraversibleRelationshipProvider sut)
    {
      rel1.Type = TheoreticalRelationshipType.Removed;

      Mock.Get(mapper).Setup(x => x.Map<TraversibleRelationship>(rel1)).Returns(trav1);

      var result = sut.GetTraversibleRelationships(new[] { rel1 }, Enumerable.Empty<HierarchicalTicketRelationship>());

      Assert.That(result, Is.Empty);
    }

    [Test, AutoMoqData]
    public void GetTraversibleRelationships_returns_mapped_hierarchical_relationships([Frozen] IMapper mapper,
                                                                                      HierarchicalTicketRelationship rel1,
                                                                                      HierarchicalTicketRelationship rel2,
                                                                                      TraversibleRelationship trav1,
                                                                                      TraversibleRelationship trav2,
                                                                                      TraversibleRelationshipProvider sut)
    {
      Mock.Get(mapper).Setup(x => x.Map<TraversibleRelationship>(rel1)).Returns(trav1);
      Mock.Get(mapper).Setup(x => x.Map<TraversibleRelationship>(rel2)).Returns(trav2);

      var result = sut.GetTraversibleRelationships(Enumerable.Empty<TheoreticalRelationship>(), new[] { rel1, rel2 });

      Assert.That(result, Is.EquivalentTo(new[] { trav1, trav2 }));
    }

    [Test, AutoMoqData]
    public void GetTraversibleRelationships_does_not_return_removed_hierarchical_relationship([Frozen] IMapper mapper,
                                                                                              TheoreticalRelationship rel1,
                                                                                              HierarchicalTicketRelationship hRel1,
                                                                                              TraversibleRelationship trav1,
                                                                                              TraversibleRelationshipProvider sut)
    {
      rel1.Type = TheoreticalRelationshipType.Removed;
      rel1.TicketRelationship = Identity.Create<TicketRelationship>(5);
      hRel1.TicketRelationship.SetIdentityValue(5);

      Mock.Get(mapper).Setup(x => x.Map<TraversibleRelationship>(rel1)).Returns(trav1);

      var result = sut.GetTraversibleRelationships(new[] { rel1 }, new[] { hRel1 });

      Assert.That(result, Is.Empty);
    }
  }
}
