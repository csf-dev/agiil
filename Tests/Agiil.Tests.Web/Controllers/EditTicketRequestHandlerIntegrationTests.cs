using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Domain.Projects;
using Agiil.Domain.Tickets;
using Agiil.Tests.Data;
using Agiil.Tests.Web;
using Agiil.Web.Controllers;
using Agiil.Web.Models.Tickets;
using Autofac;
using Autofac.Core.Lifetime;
using CSF.Data.Entities;
using CSF.Entities;
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
        builder.RegisterInstance(new CSF.Data.NoOpTransactionCreator(true)).AsSelf().AsImplementedInterfaces().SingleInstance();
        builder.RegisterInstance(Mock.Of<NHibernate.ISession>()).SingleInstance();
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
        TicketTypeIdentity = Identity.Create<TicketType>(1),
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
      ticketType.SetIdentityValue(1);
      data.Add(ticketType);

      var firstTicket = new Ticket {
        Project = project,
        TicketNumber = 11,
      };
      firstTicket.SetIdentityValue(5);
      var secondTicket = new Ticket {
        Project = project,
        TicketNumber = 22
      };
      secondTicket.SetIdentityValue(7);
      data.Add(firstTicket);
      data.Add(secondTicket);

      var relationship = new NonDirectionalRelationship {
        PrimarySummary = "Relates"
      };
      relationship.SetIdentityValue(6);
      data.Add(relationship);
    }
  }
}
