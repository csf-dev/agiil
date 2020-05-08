using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agiil.Domain.Projects;
using Agiil.Domain.Tickets;
using Agiil.Tests.Data;
using Agiil.Tests.Web;
using Agiil.Web.Controllers;
using Agiil.Web.Models.Tickets;
using Autofac;
using Autofac.Core.Lifetime;
using CSF.Entities;
using CSF.ORM;
using Moq;
using NUnit.Framework;

namespace Agiil.Tests.Tickets
{
  [TestFixture,Category("Integration"),Category("DependencyInjection")]
  public class TicketControllerIntegrationTests
  {
    IContainer container;
    ILifetimeScope diScope;
    TicketController Sut => diScope.Resolve<TicketController>();
    IEntityData Data => diScope.Resolve<IEntityData>();

    [OneTimeSetUp]
    public void FixtureSetup()
    {
      container = CachingWebAppContainerFactory.Default.GetContainer();
    }

    [SetUp]
    public void Setup()
    {
      diScope = container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag, builder => {
        builder.RegisterInstance(InMemoryEntityDataFactory.Default.GetEntityData()).SingleInstance();
        builder.RegisterInstance(new CSF.ORM.InMemory.NoOpTransactionCreator(true)).AsSelf().AsImplementedInterfaces().SingleInstance();
        builder.RegisterInstance(Mock.Of<NHibernate.ISession>()).SingleInstance();
        builder.RegisterInstance(Mock.Of<UrlHelper>()).SingleInstance();
        builder.RegisterInstance(Mock.Of<HttpRequestBase>()).SingleInstance();
      });
    }

    [TearDown]
    public void Teardown()
    {
      if(diScope != null)
        diScope.Dispose();
    }

    [Test]
    public void Edit_can_add_a_ticket_reference_by_a_qualified_reference()
    {
      SetupInitialData(Data);
      var ticketId = Identity.Create<Ticket>(5);
      var request = new EditTicketSpecification {
        Identity = ticketId,
        RelationshipsToAdd = new List<AddRelationshipModel> {
          new AddRelationshipModel {
            RelationshipIdAndParticipation = "6-Primary",
            RelatedTicketReference = new TicketReference("AB", 22)
          }
        },
        Title = "This is a ticket",
        TicketTypeIdentity = Identity.Create<TicketType>(5),
      };
      var ticket = Data.Get(ticketId);
      var expectedOtherTicket = Data.Get(Identity.Create<Ticket>(7));

      Sut.Edit(request);

      Assert.That(ticket.PrimaryRelationships.FirstOrDefault()?.SecondaryTicket, Is.SameAs(expectedOtherTicket));
    }

    void SetupInitialData(IEntityData data)
    {
      var project = new Project {
        Code = "AB"
      };
      data.Add(project);

      var ticketType = new TicketType {
        Name = "Ticket"
      };
            ((IEntity) ticketType).IdentityValue = 5L;
      data.Add(ticketType);

      var firstTicket = new Ticket {
        Project = project,
        TicketNumber = 11,
      };
      ((IEntity) firstTicket).IdentityValue = 5L;
      var secondTicket = new Ticket {
        Project = project,
        TicketNumber = 22
      };
            ((IEntity) secondTicket).IdentityValue = 7L;
      data.Add(firstTicket);
      data.Add(secondTicket);

      var relationship = new NonDirectionalRelationship {
        PrimarySummary = "Relates"
      };
            ((IEntity) relationship).IdentityValue = 6L;
      data.Add(relationship);
    }
  }
}
