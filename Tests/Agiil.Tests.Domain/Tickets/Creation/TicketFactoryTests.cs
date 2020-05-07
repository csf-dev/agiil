using System;
using Agiil.Domain;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Creation;
using Agiil.Tests.Attributes;
using Moq;
using NUnit.Framework;
using AutoFixture.NUnit3;

namespace Agiil.Tests.Tickets.Creation
{
  [TestFixture,Parallelizable]
  public class TicketFactoryTests
  {
    [Test,AutoMoqData]
    public void CreateTicket_creates_ticket_with_requested_title(TicketFactory sut,
                                                                 CreateTicketRequest request)
    {
      // Act
      var result = sut.CreateTicket(request);

      // Assert
      Assert.That(result.Title, Is.EqualTo(request.Title));
    }

    [Test,AutoMoqData]
    public void CreateTicket_creates_ticket_with_requested_description(TicketFactory sut,
                                                                       CreateTicketRequest request)
    {
      // Act
      var result = sut.CreateTicket(request);

      // Assert
      Assert.That(result.Description, Is.EqualTo(request.Description));
    }

    [Test,AutoMoqData]
    public void CreateTicket_marks_ticket_with_current_utc_timestamp([Frozen] IEnvironment environment,
                                                                     DateTime now,
                                                                     TicketFactory sut,
                                                                     CreateTicketRequest request)
    {
      // Arrange
      Mock.Get(environment)
          .Setup(x => x.GetCurrentUtcTimestamp())
          .Returns(now);

      // Act
      var result = sut.CreateTicket(request);

      // Assert
      Assert.That(result.CreationTimestamp, Is.EqualTo(now));
    }
  }
}
