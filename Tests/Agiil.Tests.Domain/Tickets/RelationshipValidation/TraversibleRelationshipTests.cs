using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.RelationshipValidation;
using Agiil.Tests.Attributes;
using CSF.Entities;
using NUnit.Framework;
using System;
namespace Agiil.Tests.Tickets.RelationshipValidation
{
  [TestFixture,Parallelizable]
  public class TraversibleRelationshipTests
  {
    [Test, AutoMoqData]
    public void Equals_returns_true_for_two_equal_identities([HasIdentity] TicketRelationship ticketRel,
                                                             [HasIdentity] DirectionalRelationship rel1,
                                                             [HasIdentity] DirectionalRelationship rel2)
    {
      var sut = new TraversibleRelationship(ticketRel.GetIdentity(), null, null, rel1.GetIdentity());
      var two = new TraversibleRelationship(ticketRel.GetIdentity(), null, null, rel2.GetIdentity());

      Assert.That(() => sut.Equals(two), Is.True);
    }

    [Test, AutoMoqData]
    public void Equals_returns_false_for_two_different_identities([HasIdentity] TicketRelationship ticketRel1,
                                                                  [HasIdentity] TicketRelationship ticketRel2,
                                                                  [HasIdentity] DirectionalRelationship rel1,
                                                                  [HasIdentity] DirectionalRelationship rel2)
    {
      var sut = new TraversibleRelationship(ticketRel1.GetIdentity(), null, null, rel1.GetIdentity());
      var two = new TraversibleRelationship(ticketRel2.GetIdentity(), null, null, rel2.GetIdentity());

      Assert.That(() => sut.Equals(two), Is.False);
    }

    [Test, AutoMoqData]
    public void Equals_returns_false_for_object([HasIdentity] TicketRelationship ticketRel,
                                                [HasIdentity] DirectionalRelationship rel1)
    {
      var sut = new TraversibleRelationship(ticketRel.GetIdentity(), null, null, rel1.GetIdentity());

      Assert.That(() => sut.Equals(new Object()), Is.False);
    }
  }
}
