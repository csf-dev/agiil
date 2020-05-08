using System;
using Agiil.Domain.Data;
using Agiil.Tests.Attributes;
using CSF.PersistenceTester;
using NHibernate;
using NUnit.Framework;
using CSF.EqualityRules;
using CSF.Collections;
using Agiil.Domain.Tickets;
using Agiil.Domain.Labels;
using Agiil.Domain.Activity;
using AutoFixture.NUnit3;
using CSF.Entities;

namespace Agiil.Tests.Data.Persistence
{
    [TestFixture, Parallelizable(ParallelScope.None)]
    public class TicketPersistenceTests
    {
        [Test, AutoData, WithDi]
        public void Entity_should_persist_successfully(Ticket ticket,
                                                       Comment comment1,
                                                       Comment comment2,
                                                       Label label1,
                                                       Label label2,
                                                       DirectionalRelationship rel1,
                                                       DirectionalRelationship rel2,
                                                       NonDirectionalRelationship rel3,
                                                       Ticket otherTicket,
                                                       TicketWorkLog log1,
                                                       TicketWorkLog log2,
                                                       [FromDi] Lazy<ISessionFactory> sessionFactory,
                                                       [FromDi] Lazy<IResetsDatabase> dbResetter)
        {
            ticket.Comments.Add(comment1);
            ticket.Comments.Add(comment2);
            ticket.Labels.Add(label1);
            ticket.Labels.Add(label2);
            ticket.PrimaryRelationships.Add(new TicketRelationship { Relationship = rel1, SecondaryTicket = otherTicket });
            ticket.PrimaryRelationships.Add(new TicketRelationship { Relationship = rel3, SecondaryTicket = otherTicket });
            ticket.SecondaryRelationships.Add(new TicketRelationship { Relationship = rel2, PrimaryTicket = otherTicket });
            ticket.WorkLogs.Add(log1);
            ticket.WorkLogs.Add(log2);

            using(var provider = new CachingDataConnectionFactoryAdapter(new CSF.ORM.NHibernate.SessionFactoryAdapter(sessionFactory.Value)))
            {
                var result = TestPersistence.UsingConnectionProvider(provider)
                      .WithSetup(s => dbResetter.Value.ResetDatabase(), false)
                      .WithEntity(ticket)
                      .WithEqualityRule(builder => {
                          return builder
                              .ForProperty(x => x.CreationTimestamp, c => c.UsingComparer(ComparerFactory.GetDateTimeAccurateToSecondsComparer()))

                              .ForProperty(x => x.Comments, c => c.UsingComparer(new SetEqualityComparer<Comment>(new EntityIdentityEqualityComparer())))
                              .ForProperty(x => x.Labels, c => c.UsingComparer(new SetEqualityComparer<Label>(new EntityIdentityEqualityComparer())))
                              .ForProperty(x => x.PrimaryRelationships, c => c.UsingComparer(new SetEqualityComparer<TicketRelationship>(new EntityIdentityEqualityComparer())))
                              .ForProperty(x => x.SecondaryRelationships, c => c.UsingComparer(new SetEqualityComparer<TicketRelationship>(new EntityIdentityEqualityComparer())))
                              .ForProperty(x => x.WorkLogs, c => c.UsingComparer(new SetEqualityComparer<TicketWorkLog>(new EntityIdentityEqualityComparer())))
                              .ForAllOtherProperties();
                      });
                Assert.That(result, Persisted.Successfully());
            }
        }
    }
}
