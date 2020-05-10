using System;
using Agiil.Domain.Data;
using Agiil.Tests.Attributes;
using CSF.PersistenceTester;
using NHibernate;
using NUnit.Framework;
using CSF.EqualityRules;
using Agiil.Domain.Tickets;
using AutoFixture.NUnit3;

namespace Agiil.Tests.Data.Persistence
{
    [TestFixture, Parallelizable(ParallelScope.None)]
    public class CommentPersistenceTests
    {
        [Test, AutoData, WithDi]
        public void Entity_should_persist_successfully(Comment comment,
                                                       [FromDi] Lazy<ISessionFactory> sessionFactory,
                                                       [FromDi] Lazy<IResetsDatabase> dbResetter)
        {
            using(var provider = new CachingDataConnectionFactoryAdapter(new CSF.ORM.NHibernate.SessionFactoryAdapter(sessionFactory.Value)))
            {
                var result = TestPersistence.UsingConnectionProvider(provider)
                      .WithSetup(s => dbResetter.Value.ResetDatabase(), false)
                      .WithEntity(comment)
                      .WithEqualityRule(builder => {
                          return builder
                              .ForProperty(x => x.CreationTimestamp, c => c.UsingComparer(ComparerFactory.GetDateTimeAccurateToSecondsComparer()))
                              .ForProperty(x => x.LastEditTimestamp, c => c.UsingComparer(ComparerFactory.GetDateTimeAccurateToSecondsComparer()))
                              .ForAllOtherProperties();
                      });
                Assert.That(result, Persisted.Successfully());
            }
        }
    }
}
