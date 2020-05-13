using System;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using Agiil.Domain.TicketSearch;
using Agiil.Tests.Attributes;
using CSF.Specifications;
using NUnit.Framework;

namespace Agiil.Tests.Tickets.Specs
{
    [TestFixture, Parallelizable]
    public class StoryPointsComparedToConstantValueSpecFactoryTests
    {
        [Test, AutoMoqData]
        public void Equals_returns_an_equals_spec(Ticket ticket, StoryPointsComparedToConstantValueSpecFactory sut)
        {
            ticket.StoryPoints = 5;
            Assert.That(() => sut.Equals(5).Matches(ticket), Is.True);
        }

        [Test, AutoMoqData]
        public void NotEquals_returns_a_not_equals_spec(Ticket ticket, StoryPointsComparedToConstantValueSpecFactory sut)
        {
            ticket.StoryPoints = 5;
            Assert.That(() => sut.NotEquals(5).Matches(ticket), Is.False);
        }

        [Test, AutoMoqData]
        public void GreaterThan_returns_a_gt_spec(Ticket ticket, StoryPointsComparedToConstantValueSpecFactory sut)
        {
            ticket.StoryPoints = 5;
            Assert.That(() => sut.GreaterThan(3).Matches(ticket), Is.True);
        }

        [Test, AutoMoqData]
        public void GreaterThanOrEqual_returns_a_gte_spec(Ticket ticket, StoryPointsComparedToConstantValueSpecFactory sut)
        {
            ticket.StoryPoints = 5;
            Assert.That(() => sut.GreaterThanOrEqual(5).Matches(ticket), Is.True);
        }

        [Test, AutoMoqData]
        public void LessThan_returns_a_lt_spec(Ticket ticket, StoryPointsComparedToConstantValueSpecFactory sut)
        {
            ticket.StoryPoints = 5;
            Assert.That(() => sut.LessThan(8).Matches(ticket), Is.True);
        }

        [Test, AutoMoqData]
        public void LessThanOrEqual_returns_a_lte_spec(Ticket ticket, StoryPointsComparedToConstantValueSpecFactory sut)
        {
            ticket.StoryPoints = 5;
            Assert.That(() => sut.LessThanOrEqual(5).Matches(ticket), Is.True);
        }

        [Test, AutoMoqData]
        public void GetFromPredicateName_can_return_a_predicate_for_every_supported_name(StoryPointsComparedToConstantValueSpecFactory sut, int value)
        {
            var supportedPredicates = new[] {
                PredicateName.Equals,
                PredicateName.NotEquals,
                PredicateName.GreaterThan,
                PredicateName.GreaterThanOrEqual,
                PredicateName.LessThan,
                PredicateName.LessThanOrEqual,
            };
            foreach(var name in supportedPredicates)
                Assert.That(() => sut.GetFromPredicateName(name, value), Is.Not.Null, $"A spec was returned for the predicate '{name}'");
        }
    }
}
