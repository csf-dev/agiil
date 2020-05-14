using System;
using Agiil.Domain.Projects;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Creation;
using Agiil.Tests.Attributes;
using Moq;
using NUnit.Framework;
using AutoFixture.NUnit3;

namespace Agiil.Tests.Tickets.Creation
{
  [TestFixture,Parallelizable]
  public class CurrentProjectSettingTicketFactoryDecoratorTests
  {
    [Test,AutoMoqData]
    public void Create_ticket_sets_project_using_current_project([Frozen,CreatesATicket] ICreatesTicket wrappedInstance,
                                                                 [Frozen] IGetsCurrentProject projectGetter,
                                                                 Project project,
                                                                 CreateTicketRequest request,
                                                                 CurrentProjectSettingTicketFactoryDecorator sut)
    {
      // Arrange
      Mock.Get(projectGetter).Setup(x => x.GetCurrentProject()).Returns(project);

      // Act
      var result = sut.CreateTicket(request);

      // Assert
      Assert.That(result?.Project, Is.SameAs(project));
    }

    [Test,AutoMoqData]
    public void Create_ticket_sets_ticket_number([Frozen,CreatesATicket] ICreatesTicket wrappedInstance,
                                                 [Frozen] IGetsCurrentProject projectGetter,
                                                 Project project,
                                                 CreateTicketRequest request,
                                                 CurrentProjectSettingTicketFactoryDecorator sut)
    {
      // Arrange
      Mock.Get(projectGetter).Setup(x => x.GetCurrentProject()).Returns(project);
      var currentTicketNumber = project.NextAvailableTicketNumber;

      // Act
      var result = sut.CreateTicket(request);

      // Assert
      Assert.That(result?.TicketNumber, Is.EqualTo(currentTicketNumber));
    }

    [Test,AutoMoqData]
    public void Create_ticket_advances_the_ticket_number([Frozen,CreatesATicket] ICreatesTicket wrappedInstance,
                                                         [Frozen] IGetsCurrentProject projectGetter,
                                                         Project project,
                                                         CreateTicketRequest request,
                                                         CurrentProjectSettingTicketFactoryDecorator sut)
    {
      // Arrange
      Mock.Get(projectGetter).Setup(x => x.GetCurrentProject()).Returns(project);
      var previousTicketNumber = project.NextAvailableTicketNumber;

      // Act
      var result = sut.CreateTicket(request);

      // Assert
      Assert.That(project.NextAvailableTicketNumber, Is.EqualTo(previousTicketNumber + 1));
    }
  }
}
