using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.RelationshipValidation;
using Agiil.Tests.Attributes;
using AutoFixture.NUnit3;
using CSF.Entities;
using log4net;
using NUnit.Framework;
using System;
namespace Agiil.Tests.Tickets.RelationshipValidation
{
    [TestFixture, Parallelizable]
    public class CircularRelationshipDetectorTests
    {
        [Test, AutoMoqData]
        public void IsRelationshipCircular_returns_true_when_a_simple_circular_relationship_exists([HasIdentity] DirectionalRelationship rel,
                                                                                                   [HasIdentity] Ticket ticket1,
                                                                                                   [HasIdentity] Ticket ticket2,
                                                                                                   [HasIdentity] Ticket ticket3,
                                                                                                   [HasIdentity] TicketRelationship tr1,
                                                                                                   [HasIdentity] TicketRelationship tr2,
                                                                                                   [HasIdentity] TicketRelationship tr3,
                                                                                                   CircularRelationshipDetector sut)
        {
            var traversibleRelationships = new[] {
                new TraversibleRelationship(tr1.GetIdentity(),
                                            ticket1.GetIdentity(),
                                            ticket2.GetIdentity(),
                                            rel.GetIdentity()),
                new TraversibleRelationship(tr2.GetIdentity(),
                                            ticket2.GetIdentity(),
                                            ticket3.GetIdentity(),
                                            rel.GetIdentity()),
                new TraversibleRelationship(tr3.GetIdentity(),
                                            ticket3.GetIdentity(),
                                            ticket1.GetIdentity(),
                                            rel.GetIdentity()),
            };

            var result = sut.IsRelationshipCircular(rel.GetIdentity(), traversibleRelationships);

            Assert.That(result, Is.True);
        }

        [Test, AutoMoqData]
        public void IsRelationshipCircular_returns_true_when_there_is_no_circular_relationship([HasIdentity] DirectionalRelationship rel,
                                                                                               [HasIdentity] Ticket ticket1,
                                                                                               [HasIdentity] Ticket ticket2,
                                                                                               [HasIdentity] Ticket ticket3,
                                                                                               [HasIdentity] TicketRelationship tr1,
                                                                                               [HasIdentity] TicketRelationship tr2,
                                                                                               CircularRelationshipDetector sut)
        {
            var traversibleRelationships = new[] {
                new TraversibleRelationship(tr1.GetIdentity(),
                                            ticket1.GetIdentity(),
                                            ticket2.GetIdentity(),
                                            rel.GetIdentity()),
                new TraversibleRelationship(tr2.GetIdentity(),
                                            ticket2.GetIdentity(),
                                            ticket3.GetIdentity(),
                                            rel.GetIdentity()),
            };

            var result = sut.IsRelationshipCircular(rel.GetIdentity(), traversibleRelationships);

            Assert.That(result, Is.False);
        }

        [Test, AutoMoqData]
        public void IsRelationshipCircular_returns_true_when_a_ticket_in_the_circle_has_no_identity([HasIdentity] DirectionalRelationship rel,
                                                                                                    [HasIdentity] Ticket ticket2,
                                                                                                    [HasIdentity] Ticket ticket3,
                                                                                                    [HasIdentity] TicketRelationship tr1,
                                                                                                    [HasIdentity] TicketRelationship tr2,
                                                                                                    [HasIdentity] TicketRelationship tr3,
                                                                                                    CircularRelationshipDetector sut)
        {
            var traversibleRelationships = new[] {
                new TraversibleRelationship(tr1.GetIdentity(),
                                            null,
                                            ticket2.GetIdentity(),
                                            rel.GetIdentity()),
                new TraversibleRelationship(tr2.GetIdentity(),
                                            ticket2.GetIdentity(),
                                            ticket3.GetIdentity(),
                                            rel.GetIdentity()),
                new TraversibleRelationship(tr3.GetIdentity(),
                                            ticket3.GetIdentity(),
                                            null,
                                            rel.GetIdentity()),
            };

            var result = sut.IsRelationshipCircular(rel.GetIdentity(), traversibleRelationships);

            Assert.That(result, Is.True);
        }

        [Test, AutoMoqData]
        public void IsRelationshipCircular_returns_true_when_complex_circle_exists([HasIdentity] DirectionalRelationship rel,
                                                                                   [HasIdentity] Ticket ticket1,
                                                                                   [HasIdentity] Ticket ticket2,
                                                                                   [HasIdentity] Ticket ticket3,
                                                                                   [HasIdentity] Ticket ticket4,
                                                                                   [HasIdentity] Ticket ticket5,
                                                                                   [HasIdentity] TicketRelationship tr1,
                                                                                   [HasIdentity] TicketRelationship tr2,
                                                                                   [HasIdentity] TicketRelationship tr3,
                                                                                   [HasIdentity] TicketRelationship tr4,
                                                                                   [HasIdentity] TicketRelationship tr5,
                                                                                   CircularRelationshipDetector sut)
        {
            var traversibleRelationships = new[] {
                new TraversibleRelationship(tr1.GetIdentity(),
                                            ticket1.GetIdentity(),
                                            ticket2.GetIdentity(),
                                            rel.GetIdentity()),
                new TraversibleRelationship(tr2.GetIdentity(),
                                            ticket2.GetIdentity(),
                                            ticket3.GetIdentity(),
                                            rel.GetIdentity()),
                new TraversibleRelationship(tr3.GetIdentity(),
                                            ticket2.GetIdentity(),
                                            ticket4.GetIdentity(),
                                            rel.GetIdentity()),
                new TraversibleRelationship(tr4.GetIdentity(),
                                            ticket5.GetIdentity(),
                                            ticket4.GetIdentity(),
                                            rel.GetIdentity()),
                new TraversibleRelationship(tr5.GetIdentity(),
                                            ticket4.GetIdentity(),
                                            ticket1.GetIdentity(),
                                            rel.GetIdentity()),
            };

            var result = sut.IsRelationshipCircular(rel.GetIdentity(), traversibleRelationships);

            Assert.That(result, Is.True);
        }

        [Test, AutoMoqData, Description("Reproduces #AG337 - where a valid hierarchy of directional relationships is mistakenly detected as invalid")]
        public void IsRelationshipCircular_returns_false_when_a_complex_non_circular_relationship_hierarchy_exists([HasIdentity] DirectionalRelationship rel1,
                                                                                                                   [HasIdentity] Ticket ticket1,
                                                                                                                   [HasIdentity] Ticket ticket2,
                                                                                                                   [HasIdentity] Ticket ticket3,
                                                                                                                   [HasIdentity] Ticket ticket4,
                                                                                                                   [HasIdentity] Ticket ticket5,
                                                                                                                   [HasIdentity] TicketRelationship tr1,
                                                                                                                   [HasIdentity] TicketRelationship tr2,
                                                                                                                   [HasIdentity] TicketRelationship tr3,
                                                                                                                   [HasIdentity] TicketRelationship tr4,
                                                                                                                   [HasIdentity] TicketRelationship tr5,
                                                                                                                   [HasIdentity] TicketRelationship tr6,
                                                                                                                   [HasIdentity] TicketRelationship tr7,
                                                                                                                   [Frozen,LoggerFor(typeof(CircularRelationshipDetector))] ILog logger,
                                                                                                                   CircularRelationshipDetector sut)
        {
            var traversibleRelationships = new[] {
                new TraversibleRelationship(tr1.GetIdentity(),
                                            ticket1.GetIdentity(),
                                            ticket2.GetIdentity(),
                                            rel1.GetIdentity()),
                new TraversibleRelationship(tr2.GetIdentity(),
                                            ticket1.GetIdentity(),
                                            ticket3.GetIdentity(),
                                            rel1.GetIdentity()),
                new TraversibleRelationship(tr3.GetIdentity(),
                                            ticket1.GetIdentity(),
                                            ticket4.GetIdentity(),
                                            rel1.GetIdentity()),
                new TraversibleRelationship(tr4.GetIdentity(),
                                            ticket2.GetIdentity(),
                                            ticket3.GetIdentity(),
                                            rel1.GetIdentity()),
                new TraversibleRelationship(tr5.GetIdentity(),
                                            ticket2.GetIdentity(),
                                            ticket4.GetIdentity(),
                                            rel1.GetIdentity()),
                new TraversibleRelationship(tr6.GetIdentity(),
                                            ticket3.GetIdentity(),
                                            ticket4.GetIdentity(),
                                            rel1.GetIdentity()),
                new TraversibleRelationship(tr7.GetIdentity(),
                                            ticket4.GetIdentity(),
                                            ticket5.GetIdentity(),
                                            rel1.GetIdentity()),
            };

            Assert.That(() => sut.IsRelationshipCircular(rel1.GetIdentity(), traversibleRelationships), Is.False);
        }
    }
}
