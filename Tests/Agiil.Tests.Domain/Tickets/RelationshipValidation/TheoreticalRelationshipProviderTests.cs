using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.RelationshipValidation;
using Agiil.Tests.Attributes;
using CSF.Collections;
using CSF.ORM;
using CSF.Entities;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Tickets.RelationshipValidation
{
  [TestFixture, Parallelizable]
  public class TheoreticalRelationshipProviderTests
  {
    [Test, AutoMoqData]
    public void GetTheoreticalTicketRelationships_returns_primary_relationships_already_present([Frozen,InMemory] IEntityData data,
                                                                                                Ticket ticket,
                                                                                                [WithRelationship] IEnumerable<TicketRelationship> relationships,
                                                                                                TheoreticalRelationshipProvider sut)
    {
      data.Add(ticket);
      foreach(var t in relationships.Select(x => x.SecondaryTicket))
        data.Add(t);
      foreach(var relationship in relationships)
        data.Add(relationship);
      ticket.PrimaryRelationships.ReplaceContents(relationships);

      var expected = relationships
        .Select(x => new TheoreticalRelationship {
          PrimaryTicket = ticket.GetIdentity(),
          SecondaryTicket = x.SecondaryTicket.GetIdentity(),
          Relationship = x.Relationship,
          TicketRelationship = x.GetIdentity(),
        })
        .ToList();

      var result = sut.GetTheoreticalTicketRelationships(ticket.GetIdentity());

      Assert.That(result, Is.EquivalentTo(expected));
    }

    [Test, AutoMoqData]
    public void GetTheoreticalTicketRelationships_returns_secondary_relationships_already_present([Frozen, InMemory] IEntityData data,
                                                                                                  Ticket ticket,
                                                                                                  [WithRelationship] IEnumerable<TicketRelationship> relationships,
                                                                                                  TheoreticalRelationshipProvider sut)
    {
      data.Add(ticket);
      foreach(var t in relationships.Select(x => x.PrimaryTicket))
        data.Add(t);
      foreach(var relationship in relationships)
        data.Add(relationship);
      ticket.SecondaryRelationships.ReplaceContents(relationships);

      var expected = relationships
        .Select(x => new TheoreticalRelationship {
          PrimaryTicket = x.PrimaryTicket.GetIdentity(),
          SecondaryTicket = ticket.GetIdentity(),
          Relationship = x.Relationship,
          TicketRelationship = x.GetIdentity(),
        })
        .ToList();

      var result = sut.GetTheoreticalTicketRelationships(ticket.GetIdentity());

      Assert.That(result, Is.EquivalentTo(expected));
    }

    [Test, AutoMoqData]
    public void GetTheoreticalTicketRelationships_marks_up_relationships_for_removal([Frozen, InMemory] IEntityData data,
                                                                                     Ticket ticket,
                                                                                     [WithRelationship] IEnumerable<TicketRelationship> relationships,
                                                                                     TicketRelationship toRemove,
                                                                                     TheoreticalRelationshipProvider sut)
    {
      data.Add(ticket);
      foreach(var t in relationships.Select(x => x.PrimaryTicket))
        data.Add(t);
      foreach(var relationship in relationships)
        data.Add(relationship);
      data.Add(toRemove);
      ticket.SecondaryRelationships.ReplaceContents(relationships);
      ticket.SecondaryRelationships.Add(toRemove);

      var expected = relationships
        .Select(x => new TheoreticalRelationship {
          PrimaryTicket = x.PrimaryTicket.GetIdentity(),
          SecondaryTicket = ticket.GetIdentity(),
          Relationship = x.Relationship,
          TicketRelationship = x.GetIdentity(),
        })
        .Append(new TheoreticalRelationship { 
          PrimaryTicket = toRemove.PrimaryTicket?.GetIdentity(),
          SecondaryTicket = toRemove.SecondaryTicket?.GetIdentity(),
          Relationship = toRemove.Relationship,
          TicketRelationship = toRemove.GetIdentity(),
          Type = TheoreticalRelationshipType.Removed,
        })
        .ToList();

      var result = sut.GetTheoreticalTicketRelationships(ticket.GetIdentity(),
                                                         removed: new[] { new DeleteRelationshipRequest { TicketRelationshipId = toRemove.GetIdentity() } });

      Assert.That(result, Is.EquivalentTo(expected));
    }
  }
}
