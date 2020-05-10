using System;
using System.Linq;
using System.Collections.Generic;
using Agiil.Bootstrap;
using Agiil.Domain.Tickets;
using Agiil.Tests.Attributes;
using Autofac;
using CSF.ORM;
using CSF.Entities;
using NUnit.Framework;
using Agiil.Domain;
using Agiil.Domain.Data;

namespace Agiil.Tests.Tickets
{
  [TestFixture,Category("Integration")]
  public class HierarchicalTicketRelationshipProviderTests
  {
    readonly IGetsAutofacContainer containerProvider = CachingDomainContainerFactory.Default;

    [Test, AutoMoqData]
    public void GetRelationships_can_get_two_direct_child_relationships(Ticket ticket1,
                                                                        Ticket ticket2,
                                                                        Ticket ticket3,
                                                                        DirectionalRelationship relationship)
    {
      var rel1 = new TicketRelationship {
        PrimaryTicket = ticket1,
        SecondaryTicket = ticket2,
        Relationship = relationship
      };
      var rel2 = new TicketRelationship {
        PrimaryTicket = ticket1,
        SecondaryTicket = ticket3,
        Relationship = relationship
      };

      var result = ExerciseSut(ticket1, rel1, rel2);

      Assert.That(result?.Count, Is.EqualTo(2), "Count of results");
      Assert.That(result?.Select(x => x?.Ticket)?.ToList(), Is.EquivalentTo(new[] { ticket1, ticket1 }), "Correct source tickets");
      Assert.That(result?.Select(x => x?.RelatedTicket)?.ToList(), Is.EquivalentTo(new[] { ticket2, ticket3 }), "Correct related tickets");
      Assert.That(result?.Select(x => x?.Direction)?.ToList(), Is.EquivalentTo(new[] { HierarchicalRelationshipDirection.Descendent, HierarchicalRelationshipDirection.Descendent }), "Correct relationship direction");
      Assert.That(result?.Select(x => x?.TicketRelationship)?.ToList(), Is.EquivalentTo(new[] { rel1, rel2 }), "Correct ticket relationships");
    }

    [Test, AutoMoqData]
    public void GetRelationships_can_get_two_direct_parent_relationships(Ticket ticket1,
                                                                         Ticket ticket2,
                                                                         Ticket ticket3,
                                                                         DirectionalRelationship relationship)
    {
      var rel1 = new TicketRelationship {
        PrimaryTicket = ticket2,
        SecondaryTicket = ticket1,
        Relationship = relationship
      };
      var rel2 = new TicketRelationship {
        PrimaryTicket = ticket3,
        SecondaryTicket = ticket1,
        Relationship = relationship
      };

      var result = ExerciseSut(ticket1, rel1, rel2);

      Assert.That(result?.Count, Is.EqualTo(2), "Count of results");
      Assert.That(result?.Select(x => x?.Ticket)?.ToList(), Is.EquivalentTo(new[] { ticket1, ticket1 }), "Correct source tickets");
      Assert.That(result?.Select(x => x?.RelatedTicket)?.ToList(), Is.EquivalentTo(new[] { ticket2, ticket3 }), "Correct related tickets");
      Assert.That(result?.Select(x => x?.Direction)?.ToList(), Is.EquivalentTo(new[] { HierarchicalRelationshipDirection.Ancestor, HierarchicalRelationshipDirection.Ancestor }), "Correct relationship direction");
      Assert.That(result?.Select(x => x?.TicketRelationship)?.ToList(), Is.EquivalentTo(new[] { rel1, rel2 }), "Correct ticket relationships");
    }

    [Test, AutoMoqData]
    public void GetRelationships_can_get_a_grandchild_relationship(Ticket ticket1,
                                                                   Ticket ticket2,
                                                                   Ticket ticket3,
                                                                   DirectionalRelationship relationship)
    {
      var rel1 = new TicketRelationship {
        PrimaryTicket = ticket1,
        SecondaryTicket = ticket2,
        Relationship = relationship
      };
      var rel2 = new TicketRelationship {
        PrimaryTicket = ticket2,
        SecondaryTicket = ticket3,
        Relationship = relationship
      };

      var result = ExerciseSut(ticket1, rel1, rel2);

      Assert.That(result?.Count, Is.EqualTo(2), "Count of results");
      Assert.That(result?.Select(x => x?.Ticket)?.ToList(), Is.EquivalentTo(new[] { ticket1, ticket1 }), "Correct source tickets");
      Assert.That(result?.Select(x => x?.RelatedTicket)?.ToList(), Is.EquivalentTo(new[] { ticket2, ticket3 }), "Correct related tickets");
      Assert.That(result?.Select(x => x?.Direction)?.ToList(), Is.EquivalentTo(new[] { HierarchicalRelationshipDirection.Descendent, HierarchicalRelationshipDirection.Descendent }), "Correct relationship direction");
      Assert.That(result?.Select(x => x?.TicketRelationship)?.ToList(), Is.EquivalentTo(new[] { rel1, rel2 }), "Correct ticket relationships");
    }

    [Test, AutoMoqData]
    public void GetRelationships_can_get_a_grandparent_relationship(Ticket ticket1,
                                                                    Ticket ticket2,
                                                                    Ticket ticket3,
                                                                    DirectionalRelationship relationship)
    {
      var rel1 = new TicketRelationship {
        PrimaryTicket = ticket2,
        SecondaryTicket = ticket1,
        Relationship = relationship
      };
      var rel2 = new TicketRelationship {
        PrimaryTicket = ticket3,
        SecondaryTicket = ticket2,
        Relationship = relationship
      };

      var result = ExerciseSut(ticket1, rel1, rel2);

      Assert.That(result?.Count, Is.EqualTo(2), "Count of results");
      Assert.That(result?.Select(x => x?.Ticket)?.ToList(), Is.EquivalentTo(new[] { ticket1, ticket1 }), "Correct source tickets");
      Assert.That(result?.Select(x => x?.RelatedTicket)?.ToList(), Is.EquivalentTo(new[] { ticket2, ticket3 }), "Correct related tickets");
      Assert.That(result?.Select(x => x?.Direction)?.ToList(), Is.EquivalentTo(new[] { HierarchicalRelationshipDirection.Ancestor, HierarchicalRelationshipDirection.Ancestor }), "Correct relationship direction");
      Assert.That(result?.Select(x => x?.TicketRelationship)?.ToList(), Is.EquivalentTo(new[] { rel1, rel2 }), "Correct ticket relationships");
    }

    List<HierarchicalTicketRelationship> ExerciseSut(Ticket ticket, params TicketRelationship[] relationships)
    {
      using(var scope = containerProvider.GetContainer().BeginLifetimeScope(ComponentScope.ApplicationConnection))
      {
        var dbResetter = scope.Resolve<IResetsDatabase>();
        dbResetter.ResetDatabase();

        var data = scope.Resolve<IEntityData>();
        var tranProvider = scope.Resolve<IGetsTransaction>();

        using(var tran = tranProvider.GetTransaction())
        {
          foreach(var relationship in relationships)
            data.Add(relationship);

          tran.Commit();
        }

        var sut = scope.Resolve<HierarchicalTicketRelationshipProvider>();
        return sut.GetRelationships(ticket.GetIdentity()).ToList();
      }
    }
  }
}
