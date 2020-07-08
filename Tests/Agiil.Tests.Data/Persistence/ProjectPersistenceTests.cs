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
using Agiil.Domain.Auth;

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
                                                       User contrib1,
                                                       User contrib2,
                                                       User admin1,
                                                       User admin2,
                                                       [FromDi] Lazy<ISessionFactory> sessionFactory,
                                                       [FromDi] Lazy<IResetsDatabase> dbResetter)
        {
            project.Tickets.Add(ticket1);
            project.Tickets.Add(ticket2);
            project.Sprints.Add(sprint1);
            project.Sprints.Add(sprint2);
            project.Contributors.Add(contrib1);
            project.Contributors.Add(contrib2);
            project.Administrators.Add(admin1);
            project.Administrators.Add(admin2);

            using(var provider = new CachingDataConnectionFactoryAdapter(new CSF.ORM.NHibernate.SessionFactoryAdapter(sessionFactory.Value)))
            {
                var result = TestPersistence.UsingConnectionProvider(provider)
                  .WithSetup(s => {
                      dbResetter.Value.ResetDatabase();
                      using(var tran = s.GetTransactionFactory().GetTransaction())
                      {
                          var p = s.GetPersister();
                          p.Add(contrib1);
                          p.Add(contrib2);
                          p.Add(admin1);
                          p.Add(admin2);
                          tran.Commit();
                      }
                  }, false)
                  .WithEntity(project)
                  .WithEqualityRule(builder => {
                      return builder
                          .ForProperty(x => x.Tickets, c => c.UsingComparer(new SetEqualityComparer<Ticket>(new EntityIdentityEqualityComparer())))
                          .ForProperty(x => x.Sprints, c => c.UsingComparer(new SetEqualityComparer<Sprint>(new EntityIdentityEqualityComparer())))
                          .ForProperty(x => x.Contributors, c => c.UsingComparer(new SetEqualityComparer<User>(new EntityIdentityEqualityComparer())))
                          .ForProperty(x => x.Administrators, c => c.UsingComparer(new SetEqualityComparer<User>(new EntityIdentityEqualityComparer())))
                          .ForAllOtherProperties();
                  });
                Assert.That(result, Persisted.Successfully());
            }
        }
    }
}
