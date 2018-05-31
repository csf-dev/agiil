using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Domain;
using Agiil.Domain.Auth;
using Agiil.Domain.Labels;
using Agiil.Domain.Tickets;
using Agiil.Tests.Attributes;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Tickets
{
  [TestFixture,Parallelizable]
  public class TicketFactoryTests
  {
    [Test,AutoMoqData]
    public void CreateTicket_creates_ticket_with_requested_title(TicketFactory sut,
                                                                 CreateTicketRequest request,
                                                                 User user)
    {
      // Act
      var result = sut.CreateTicket(request, user);

      // Assert
      Assert.That(result.Title, Is.EqualTo(request.Title));
    }

    [Test,AutoMoqData]
    public void CreateTicket_creates_ticket_with_requested_description(TicketFactory sut,
                                                                       CreateTicketRequest request,
                                                                       User user)
    {
      // Act
      var result = sut.CreateTicket(request, user);

      // Assert
      Assert.That(result.Description, Is.EqualTo(request.Description));
    }

    [Test,AutoMoqData]
    public void CreateTicket_creates_ticket_with_requested_user(TicketFactory sut,
                                                                CreateTicketRequest request,
                                                                User user)
    {
      // Act
      var result = sut.CreateTicket(request, user);

      // Assert
      Assert.That(result.User, Is.SameAs(user));
    }

    [Test,AutoMoqData]
    public void CreateTicket_marks_ticket_with_current_utc_timestamp([Frozen] IEnvironment environment,
                                                                     DateTime now,
                                                                     TicketFactory sut,
                                                                     CreateTicketRequest request,
                                                                     User user)
    {
      // Arrange
      Mock.Get(environment)
          .Setup(x => x.GetCurrentUtcTimestamp())
          .Returns(now);

      // Act
      var result = sut.CreateTicket(request, user);

      // Assert
      Assert.That(result.CreationTimestamp, Is.EqualTo(now));
    }

    [Test,AutoMoqData]
    public void CreateTicket_adds_labels_to_ticket([Frozen] IGetsLabels labelProvider,
                                                   TicketFactory sut,
                                                   CreateTicketRequest request,
                                                   User user,
                                                   IEnumerable<Label> labels)
    {
      // Arrange
      Mock.Get(labelProvider)
          .Setup(x => x.GetLabels(request.CommaSeparatedLabelNames))
          .Returns(labels.ToArray());

      // Act
      var result = sut.CreateTicket(request, user);

      // Assert
      Assert.That(result.Labels, Is.EquivalentTo(labels));
    }
  }
}
