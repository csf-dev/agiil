using System;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using Agiil.Tests.Attributes;
using CSF.Specifications;
using NUnit.Framework;

namespace Agiil.Tests.Tickets.Specs
{
    [TestFixture,Parallelizable]
    public class HasNoStoryPointsTests
    {
        [Test, AutoMoqData]
        public void Matches_returns_true_for_a_ticket_without_story_points(Ticket ticket, HasNoStoryPoints sut)
        {
            ticket.StoryPoints = null;
            Assert.That(() => sut.Matches(ticket), Is.True);
        }

        [Test, AutoMoqData]
        public void Matches_returns_false_for_a_ticket_with_story_points(Ticket ticket, HasNoStoryPoints sut)
        {
            ticket.StoryPoints = 5;
            Assert.That(() => sut.Matches(ticket), Is.False);
        }
    }
}
