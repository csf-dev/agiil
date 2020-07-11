using System;
using Agiil.Domain.Data;
using Agiil.Tests.Attributes;
using CSF.PersistenceTester;
using NHibernate;
using NUnit.Framework;
using CSF.EqualityRules;
using Agiil.Domain.Tickets;
using AutoFixture.NUnit3;
using Agiil.Domain.Auth;
using CSF.Collections;
using CSF.Entities;
using Agiil.Domain.Projects;

namespace Agiil.Tests.Data.Persistence
{
    [TestFixture, Parallelizable(ParallelScope.None)]
    public class UserPersistenceTests
    {
        [Test, AutoData, WithDi]
        public void Entity_should_persist_successfully(User user,
                                                       Project contrib1,
                                                       Project contrib2,
                                                       Project admin1,
                                                       Project admin2,
                                                       [FromDi] Lazy<ISessionFactory> sessionFactory,
                                                       [FromDi] Lazy<IResetsDatabase> dbResetter)
        {
            user.ContributorTo.Add(contrib1);
            user.ContributorTo.Add(contrib2);
            user.AdministratorOf.Add(admin1);
            user.AdministratorOf.Add(admin2);

            using(var provider = new CachingDataConnectionFactoryAdapter(new CSF.ORM.NHibernate.SessionFactoryAdapter(sessionFactory.Value)))
            {
                var result = TestPersistence.UsingConnectionProvider(provider)
                      .WithSetup(s => dbResetter.Value.ResetDatabase(), false)
                      .WithEntity(user)
                      .WithEqualityRule(builder => {
                          return builder
                          .ForProperty(x => x.ContributorTo, c => c.UsingComparer(new SetEqualityComparer<Project>(new EntityIdentityEqualityComparer())))
                          .ForProperty(x => x.AdministratorOf, c => c.UsingComparer(new SetEqualityComparer<Project>(new EntityIdentityEqualityComparer())))
                              .ForAllOtherProperties();
                      });
                Assert.That(result, Persisted.Successfully());
            }
        }
    }
}
