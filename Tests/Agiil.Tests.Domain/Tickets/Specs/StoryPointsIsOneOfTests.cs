using System;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using Agiil.Tests.Attributes;
using CSF.Specifications;
using NUnit.Framework;

namespace Agiil.Tests.Tickets.Specs
{
    [TestFixture, Parallelizable]
    public class StoryPointsIsOneOfTests
    {
        [Test, AutoMoqData]
        public void Matches_returns_false_for_a_ticket_without_story_points(Ticket ticket)
        {
            var sut = new StoryPointsIsOneOf(new[] { 2, 3, 4 });
            ticket.StoryPoints = null;
            Assert.That(() => sut.Matches(ticket), Is.False);
        }

        [Test, AutoMoqData]
        public void Matches_returns_false_for_a_ticket_with_story_points_not_in_the_list(Ticket ticket)
        {
            var sut = new StoryPointsIsOneOf(new[] { 2, 3, 4 });
            ticket.StoryPoints = 10;
            Assert.That(() => sut.Matches(ticket), Is.False);
        }

        [Test, AutoMoqData]
        public void Matches_returns_true_for_a_ticket_with_story_points_in_the_list(Ticket ticket)
        {
            var sut = new StoryPointsIsOneOf(new[] { 2, 3, 4 });
            ticket.StoryPoints = 4;
            Assert.That(() => sut.Matches(ticket), Is.True);
        }
    }
}
