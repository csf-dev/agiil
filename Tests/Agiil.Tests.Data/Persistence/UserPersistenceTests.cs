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

namespace Agiil.Tests.Data.Persistence
{
    [TestFixture, Parallelizable(ParallelScope.None)]
    public class UserPersistenceTests
    {
        [Test, AutoData, WithDi]
        public void Entity_should_persist_successfully(User user,
                                                       [FromDi] Lazy<ISessionFactory> sessionFactory,
                                                       [FromDi] Lazy<IResetsDatabase> dbResetter)
        {
            using(var provider = new CachingDataConnectionFactoryAdapter(new CSF.ORM.NHibernate.SessionFactoryAdapter(sessionFactory.Value)))
            {
                var result = TestPersistence.UsingConnectionProvider(provider)
                      .WithSetup(s => dbResetter.Value.ResetDatabase(), false)
                      .WithEntity(user)
                      .WithEqualityRule(builder => {
                          return builder
                              .ForAllOtherProperties();
                      });
                Assert.That(result, Persisted.Successfully());
            }
        }
    }
}
