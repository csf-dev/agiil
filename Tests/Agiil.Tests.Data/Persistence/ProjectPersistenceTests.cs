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
    public class ProjectPersistenceTests
    {
        [Test, AutoData, WithDi]
        public void Entity_should_persist_successfully(Project project,
                                                       Ticket ticket1,
                                                       Ticket ticket2,
                                                       Sprint sprint1,
                                                       Sprint sprint2,
                                                       [FromDi] Lazy<ISessionFactory> sessionFactory,
                                                       [FromDi] Lazy<IResetsDatabase> dbResetter)
        {
            project.Tickets.Add(ticket1);
            project.Tickets.Add(ticket2);
            project.Sprints.Add(sprint1);
            project.Sprints.Add(sprint2);

            using(var provider = new CachingDataConnectionFactoryAdapter(new CSF.ORM.NHibernate.SessionFactoryAdapter(sessionFactory.Value)))
            {
                var result = TestPersistence.UsingConnectionProvider(provider)
                  .WithSetup(s => dbResetter.Value.ResetDatabase(), false)
                  .WithEntity(project)
                  .WithEqualityRule(builder => {
                      return builder
                          .ForProperty(x => x.Tickets, c => c.UsingComparer(new SetEqualityComparer<Ticket>(new EntityIdentityEqualityComparer())))
                          .ForProperty(x => x.Sprints, c => c.UsingComparer(new SetEqualityComparer<Sprint>(new EntityIdentityEqualityComparer())))
                          .ForAllOtherProperties();
                  });
                Assert.That(result, Persisted.Successfully());
            }
        }
    }
}
