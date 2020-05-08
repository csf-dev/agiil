using System;
using Agiil.Domain.Projects;
using Agiil.Tests.Attributes;
using NHibernate;
using NUnit.Framework;
using CSF.PersistenceTester;
using CSF.EqualityRules;
using CSF.Collections;
using Agiil.Domain.Tickets;
using Agiil.Domain.Sprints;
using Agiil.Domain.Data;
using AutoFixture.NUnit3;
using CSF.Entities;

namespace Agiil.Tests.Data.Persistence
{
    [TestFixture, Parallelizable(ParallelScope.None)]
    public class TicketRelationshipPersistenceTests
    {
        [Test, AutoData, WithDi]
        public void Entity_should_persist_successfully([NoAutoProperties] TicketRelationship ticketRelationship,
                                                       DirectionalRelationship relationship,
                                                       Ticket primary,
                                                       Ticket secondary,
                                                       [FromDi] Lazy<ISessionFactory> sessionFactory,
                                                       [FromDi] Lazy<IResetsDatabase> dbResetter)
        {
            ticketRelationship.Relationship = relationship;
            ticketRelationship.PrimaryTicket = primary;
            ticketRelationship.SecondaryTicket = secondary;

            using(var provider = new CachingDataConnectionFactoryAdapter(new CSF.ORM.NHibernate.SessionFactoryAdapter(sessionFactory.Value)))
            {
                var result = TestPersistence.UsingConnectionProvider(provider)
                  .WithSetup(s => dbResetter.Value.ResetDatabase(), false)
                  .WithEntity(ticketRelationship)
                  .WithEqualityRule(builder => {
                      return builder
                          .ForAllOtherProperties();
                  });
                Assert.That(result, Persisted.Successfully());
            }
        }
    }
}
