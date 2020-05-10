using System;
using System.Linq;
using Agiil.Domain.Data;
using Agiil.Domain.Projects;
using Agiil.Domain.Tickets;
using Agiil.Tests.Attributes;
using AutoFixture.NUnit3;
using CSF.Entities;
using CSF.ORM;
using CSF.Validation.Rules;
using log4net;
using NUnit.Framework;

namespace Agiil.Tests.Tickets.RelationshipValidation
{
    [TestFixture,Category("Integration")]
    public class AddTicketRelationshipIntegrationTests
    {
        static readonly ILog logger = LogManager.GetLogger(typeof(AddTicketRelationshipIntegrationTests));

        [Test, AutoData, WithDi]
        public void A_user_can_add_a_hierarchical_ticket_relationship(Project project,
                                                                      Ticket childTicket,
                                                                      Ticket parentTicket,
                                                                      TicketType type,
                                                                      DirectionalRelationship parentChildRelationship,
                                                                      [FromDi] Lazy<IEntityData> data,
                                                                      [FromDi] Lazy<IGetsTransaction> tranFactory,
                                                                      [FromDi] Lazy<IHandlesEditTicketRequest> sut)
        {
            project.Code = "AddTicketRelationshipIntegrationTests.A_user_can_add_a_hierarchical_ticket_relationship";

            parentChildRelationship.Behaviour.ProhibitCircularRelationship = true;
            parentChildRelationship.Behaviour.ProhibitMultipleSecondaryRelationships = false;

            childTicket.Project = project;
            childTicket.TicketNumber = 1;
            childTicket.Type = type;

            parentTicket.Project = project;
            parentTicket.TicketNumber = 2;
            parentTicket.Type = type;

            using(var tran = tranFactory.Value.GetTransaction())
            {
                data.Value.Add(project);
                data.Value.Add(parentChildRelationship);
                data.Value.Add(parentTicket);
                data.Value.Add(type);
                tran.Commit();
            }

            var editRequest = new EditTicketRequest {
                Identity = parentTicket.GetIdentity(),
                CommaSeparatedLabelNames = String.Empty,
                Description = "This is a description",
                SprintIdentity = null,
                Title = "This is a title",
                TicketTypeIdentity = type.GetIdentity(),
                RelationshipsToAdd = new [] {
                    new AddRelationshipRequest {
                        ParticipationType = RelationshipParticipant.Secondary,
                        RelatedTicketReference = childTicket.GetTicketReference(),
                        RelationshipId = parentChildRelationship.GetIdentity(),
                    },
                },
            };

            var result = sut.Value.Edit(editRequest);

            if(result?.IsSuccess != true)
            {
                var unsuccessfulRules = result.ValidationResult.RuleResults.Where(x => x.RuleResult.Outcome != RuleOutcome.Success);
                logger.Error($"Failed results are: {String.Join(", ", unsuccessfulRules.Select(x => $"{x.ManifestIdentity}: {x.RuleResult.Outcome}"))}");
            }

            Assert.That(result?.IsSuccess, Is.True);
        }

        [Test, AutoData, WithDi, Description("Reproduces #AG337 - where tickets in a complex relationship structure prevent the addition of a new (valid) relationship")]
        public void A_user_may_add_a_relatinship_to_a_complex_multipath_directional_relationship_structure(Project project,
                                                                                                           Ticket editedTicket,
                                                                                                           Ticket blockedTicket1,
                                                                                                           Ticket blockedTicket2,
                                                                                                           Ticket blockedTicket3,
                                                                                                           Ticket blockedTicket4,
                                                                                                           Ticket parentTicket,
                                                                                                           TicketType type,
                                                                                                           DirectionalRelationship blocks,
                                                                                                           DirectionalRelationship childOf,
                                                                                                           [FromDi] Lazy<IEntityData> data,
                                                                                                           [FromDi] Lazy<IGetsTransaction> tranFactory,
                                                                                                           [FromDi] Lazy<IHandlesEditTicketRequest> sut)
        {
            /* The summary of the test data is that there are two directional relationships (block & child-of)
             * which prohibit circular relationships.  The edited ticket blocks other tickets 1, 2 & 3.
             * Other ticket 1 blocks other tickets 2 & 3.  Other ticket 2 blocks other ticket 3. Other ticket 3
             * blocks other ticket 4.  This is valid because the blocks flow in only one direction and cannot get
             * back to a parent ticket.
             * 
             * In the test, we are adding a new child-of relationship to the edited ticket, making it a child of
             * the parent ticket.
             */

            #region Setup test data

            project.Code = "AddTicketRelationshipIntegrationTests.A_user_may_add_a_relatinship_to_a_complex_multipath_directional_relationship_structure";

            blocks.Behaviour.ProhibitCircularRelationship = true;
            blocks.Behaviour.ProhibitMultipleSecondaryRelationships = false;

            childOf.Behaviour.ProhibitCircularRelationship = true;
            childOf.Behaviour.ProhibitMultipleSecondaryRelationships = false;

            editedTicket.Project = project;
            editedTicket.TicketNumber = 1;
            editedTicket.Type = type;

            blockedTicket1.Project = project;
            blockedTicket1.TicketNumber = 2;
            blockedTicket1.Type = type;

            blockedTicket1.Project = project;
            blockedTicket1.TicketNumber = 3;
            blockedTicket1.Type = type;

            blockedTicket1.Project = project;
            blockedTicket1.TicketNumber = 4;
            blockedTicket1.Type = type;

            blockedTicket1.Project = project;
            blockedTicket1.TicketNumber = 5;
            blockedTicket1.Type = type;

            parentTicket.Project = project;
            parentTicket.TicketNumber = 6;
            parentTicket.Type = type;

            editedTicket.PrimaryRelationships.Add(new TicketRelationship { SecondaryTicket = blockedTicket1, Relationship = blocks });
            editedTicket.PrimaryRelationships.Add(new TicketRelationship { SecondaryTicket = blockedTicket2, Relationship = blocks });
            editedTicket.PrimaryRelationships.Add(new TicketRelationship { SecondaryTicket = blockedTicket3, Relationship = blocks });
            blockedTicket1.PrimaryRelationships.Add(new TicketRelationship { SecondaryTicket = blockedTicket2, Relationship = blocks });
            blockedTicket1.PrimaryRelationships.Add(new TicketRelationship { SecondaryTicket = blockedTicket3, Relationship = blocks });
            blockedTicket2.PrimaryRelationships.Add(new TicketRelationship { SecondaryTicket = blockedTicket3, Relationship = blocks });
            blockedTicket3.PrimaryRelationships.Add(new TicketRelationship { SecondaryTicket = blockedTicket4, Relationship = blocks });

            using(var tran = tranFactory.Value.GetTransaction())
            {
                data.Value.Add(project);
                data.Value.Add(blocks);
                data.Value.Add(childOf);
                data.Value.Add(editedTicket);
                data.Value.Add(parentTicket);
                data.Value.Add(type);
                tran.Commit();
            }

            #endregion

            var editRequest = new EditTicketRequest {
                Identity = editedTicket.GetIdentity(),
                Title = "This is a title",
                TicketTypeIdentity = type.GetIdentity(),
                RelationshipsToAdd = new[] {
                    new AddRelationshipRequest {
                        ParticipationType = RelationshipParticipant.Secondary,
                        RelatedTicketReference = parentTicket.GetTicketReference(),
                        RelationshipId = childOf.GetIdentity(),
                    },
                },
            };

            var result = sut.Value.Edit(editRequest);

            if(result?.IsSuccess != true)
            {
                var unsuccessfulRules = result.ValidationResult.RuleResults.Where(x => x.RuleResult.Outcome != RuleOutcome.Success);
                logger.Error($"Failed results are: {String.Join(", ", unsuccessfulRules.Select(x => $"{x.ManifestIdentity}: {x.RuleResult.Outcome}"))}");
            }

            Assert.That(result?.IsSuccess, Is.True);
        }
    }
}
