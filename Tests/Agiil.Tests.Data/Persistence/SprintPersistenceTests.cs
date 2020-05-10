using System;
using Agiil.Domain.Data;
using Agiil.Domain.Sprints;
using Agiil.Tests.Attributes;
using CSF.PersistenceTester;
using NHibernate;
using NUnit.Framework;
using CSF.EqualityRules;
using CSF.Collections;
using Agiil.Domain.Tickets;
using AutoFixture.NUnit3;
using CSF.Entities;

namespace Agiil.Tests.Data.Persistence
{
    [TestFixture, Parallelizable(ParallelScope.None)]
    public class SprintPersistenceTests
    {
        [Test, AutoData, WithDi]
        public void Entity_should_persist_successfully(Sprint sprint,
                                                       Ticket ticket1,
                                                       Ticket ticket2,
                                                       [FromDi] Lazy<ISessionFactory> sessionFactory,
                                                       [FromDi] Lazy<IResetsDatabase> dbResetter)
        {
            sprint.Tickets.Add(ticket1);
            sprint.Tickets.Add(ticket2);

            using(var provider = new CachingDataConnectionFactoryAdapter(new CSF.ORM.NHibernate.SessionFactoryAdapter(sessionFactory.Value)))
            {
                var result = TestPersistence.UsingConnectionProvider(provider)
                  .WithSetup(s => dbResetter.Value.ResetDatabase(), false)
                  .WithEntity(sprint)
                  .WithEqualityRule(builder => {
                      return builder
                            .ForProperty(x => x.CreationDate, c => c.UsingComparer(ComparerFactory.GetDateTimeAccurateToSecondsComparer()))
                            .ForProperty(x => x.StartDate, c => c.UsingComparer(ComparerFactory.GetNullableDateTimeAccurateToSecondsComparer()))
                            .ForProperty(x => x.EndDate, c => c.UsingComparer(ComparerFactory.GetNullableDateTimeAccurateToSecondsComparer()))
                          .ForProperty(x => x.Tickets, c => c.UsingComparer(new SetEqualityComparer<Ticket>(new EntityIdentityEqualityComparer())))
                          .ForAllOtherProperties();
                  });
                Assert.That(result, Persisted.Successfully());
            }
        }
    }
}
