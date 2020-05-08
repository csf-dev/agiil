using System;
using Agiil.Domain.Data;
using Agiil.Tests.Attributes;
using CSF.PersistenceTester;
using NHibernate;
using NUnit.Framework;
using CSF.EqualityRules;
using Agiil.Domain.Tickets;
using AutoFixture.NUnit3;
using Agiil.Domain.Labels;
using CSF.Entities;
using CSF.Collections;
using System.Linq;
using System.Collections.Generic;

namespace Agiil.Tests.Data.Persistence
{
    [TestFixture, Parallelizable(ParallelScope.None)]
    public class LabelPersistenceTests
    {
        [Test, AutoData, WithDi]
        public void Entity_should_persist_successfully(Label label,
                                                       Ticket ticket1,
                                                       Ticket ticket2,
                                                       [FromDi] Lazy<ISessionFactory> sessionFactory,
                                                       [FromDi] Lazy<IResetsDatabase> dbResetter)
        {
            label.Tickets.Add(ticket1);
            label.Tickets.Add(ticket2);

            using(var provider = new CachingDataConnectionFactoryAdapter(new CSF.ORM.NHibernate.SessionFactoryAdapter(sessionFactory.Value)))
            {
                var result = TestPersistence.UsingConnectionProvider(provider)
                      .WithSetup(s => {
                          dbResetter.Value.ResetDatabase();

                          // The many-to-many from Label to Ticket doesn't cascade from the Label side,
                          // so the tickets must be saved independently.
                          using(var tran = s.GetTransactionFactory().GetTransaction())
                          {
                              var persister = s.GetPersister();
                              persister.Add(ticket1);
                              persister.Add(ticket2);
                              tran.Commit();
                          }
                      }, false)
                      .WithEntity(label)
                      .WithEqualityRule(builder => {
                          return builder
                              .ForProperty(x => x.Tickets, c => c.UsingComparer(new SetEqualityComparer<Ticket>(new EntityIdentityEqualityComparer())))
                              .ForAllOtherProperties();
                      });

                Assert.That(result, Persisted.Successfully());
            }
        }
    }
}
