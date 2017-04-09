using System;
using Agiil.Domain;
using Agiil.Domain.Auth;
using Agiil.Domain.Tickets;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Services.Tickets
{
  [TestFixture]
  public class TicketFactoryTests
  {
    [Test,AutoMoqData]
    public void CreateTicket_creates_ticket_with_requested_title(TicketFactory sut,
                                                                 string title,
                                                                 string description,
                                                                 User user)
    {
      // Act
      var result = sut.CreateTicket(title, description, user);

      // Assert
      Assert.AreEqual(title, result.Title);
    }

    [Test,AutoMoqData]
    public void CreateTicket_creates_ticket_with_requested_description(TicketFactory sut,
                                                                       string title,
                                                                       string description,
                                                                       User user)
    {
      // Act
      var result = sut.CreateTicket(title, description, user);

      // Assert
      Assert.AreEqual(description, result.Description);
    }

    [Test,AutoMoqData]
    public void CreateTicket_creates_ticket_with_requested_user(TicketFactory sut,
                                                                string title,
                                                                string description,
                                                                User user)
    {
      // Act
      var result = sut.CreateTicket(title, description, user);

      // Assert
      Assert.AreSame(user, result.User);
    }

    [Test,AutoMoqData]
    public void CreateTicket_marks_ticket_with_current_utc_timestamp([Frozen] IEnvironment environment,
                                                                     DateTime now,
                                                                     TicketFactory sut,
                                                                     string title,
                                                                     string description,
                                                                     User user)
    {
      // Arrange
      Mock.Get(environment)
          .Setup(x => x.GetCurrentUtcTimestamp())
          .Returns(now);

      // Act
      var result = sut.CreateTicket(title, description, user);

      // Assert
      Assert.AreEqual(now, result.CreationTimestamp);
    }
  }
}
