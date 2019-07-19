﻿using System;
using System.Linq;
using System.Collections.Generic;
using Agiil.Bootstrap;
using Agiil.Domain.Tickets;
using Agiil.Tests.Attributes;
using Autofac;
using CSF.Data;
using CSF.Data.Entities;
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

      List<HierarchicalTicketRelationship> result;

      using(var scope = containerProvider.GetContainer().BeginLifetimeScope(ComponentScope.ApplicationConnection))
      {
        var dbResetter = scope.Resolve<IResetsDatabase>();
        dbResetter.ResetDatabase();

        var data = scope.Resolve<IEntityData>();
        var tranProvider = scope.Resolve<ITransactionCreator>();

        using(var tran = tranProvider.BeginTransaction())
        {
          data.Add(rel1);
          data.Add(rel2);
          tran.Commit();
        }

        var sut = scope.Resolve<HierarchicalTicketRelationshipProvider>();
        result = sut.GetRelationships(ticket1.GetIdentity()).ToList();
      }

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

      List<HierarchicalTicketRelationship> result;

      using(var scope = containerProvider.GetContainer().BeginLifetimeScope(ComponentScope.ApplicationConnection))
      {
        var dbResetter = scope.Resolve<IResetsDatabase>();
        dbResetter.ResetDatabase();

        var data = scope.Resolve<IEntityData>();
        var tranProvider = scope.Resolve<ITransactionCreator>();

        using(var tran = tranProvider.BeginTransaction())
        {
          data.Add(rel1);
          data.Add(rel2);
          tran.Commit();
        }

        var sut = scope.Resolve<HierarchicalTicketRelationshipProvider>();
        result = sut.GetRelationships(ticket1.GetIdentity()).ToList();
      }

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

      List<HierarchicalTicketRelationship> result;

      using(var scope = containerProvider.GetContainer().BeginLifetimeScope(ComponentScope.ApplicationConnection))
      {
        var dbResetter = scope.Resolve<IResetsDatabase>();
        dbResetter.ResetDatabase();

        var data = scope.Resolve<IEntityData>();
        var tranProvider = scope.Resolve<ITransactionCreator>();

        using(var tran = tranProvider.BeginTransaction())
        {
          data.Add(rel1);
          data.Add(rel2);
          tran.Commit();
        }

        var sut = scope.Resolve<HierarchicalTicketRelationshipProvider>();
        result = sut.GetRelationships(ticket1.GetIdentity()).ToList();
      }

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

      List<HierarchicalTicketRelationship> result;

      using(var scope = containerProvider.GetContainer().BeginLifetimeScope(ComponentScope.ApplicationConnection))
      {
        var dbResetter = scope.Resolve<IResetsDatabase>();
        dbResetter.ResetDatabase();

        var data = scope.Resolve<IEntityData>();
        var tranProvider = scope.Resolve<ITransactionCreator>();

        using(var tran = tranProvider.BeginTransaction())
        {
          data.Add(rel1);
          data.Add(rel2);
          tran.Commit();
        }

        var sut = scope.Resolve<HierarchicalTicketRelationshipProvider>();
        result = sut.GetRelationships(ticket1.GetIdentity()).ToList();
      }

      Assert.That(result?.Count, Is.EqualTo(2), "Count of results");
      Assert.That(result?.Select(x => x?.Ticket)?.ToList(), Is.EquivalentTo(new[] { ticket1, ticket1 }), "Correct source tickets");
      Assert.That(result?.Select(x => x?.RelatedTicket)?.ToList(), Is.EquivalentTo(new[] { ticket2, ticket3 }), "Correct related tickets");
      Assert.That(result?.Select(x => x?.Direction)?.ToList(), Is.EquivalentTo(new[] { HierarchicalRelationshipDirection.Ancestor, HierarchicalRelationshipDirection.Ancestor }), "Correct relationship direction");
      Assert.That(result?.Select(x => x?.TicketRelationship)?.ToList(), Is.EquivalentTo(new[] { rel1, rel2 }), "Correct ticket relationships");
    }
  }
}