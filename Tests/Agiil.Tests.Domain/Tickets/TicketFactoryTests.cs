﻿using System;
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
                                                                 string title,
                                                                 string description,
                                                                 User user,
                                                                 TicketType type)
    {
      // Act
      var result = sut.CreateTicket(title, description, user, type);

      // Assert
      Assert.AreEqual(title, result.Title);
    }

    [Test,AutoMoqData]
    public void CreateTicket_creates_ticket_with_requested_description(TicketFactory sut,
                                                                       string title,
                                                                       string description,
                                                                       User user,
                                                                       TicketType type)
    {
      // Act
      var result = sut.CreateTicket(title, description, user, type);

      // Assert
      Assert.AreEqual(description, result.Description);
    }

    [Test,AutoMoqData]
    public void CreateTicket_creates_ticket_with_requested_user(TicketFactory sut,
                                                                string title,
                                                                string description,
                                                                User user,
                                                                TicketType type)
    {
      // Act
      var result = sut.CreateTicket(title, description, user, type);

      // Assert
      Assert.AreSame(user, result.User);
    }

    [Test,AutoMoqData]
    public void CreateTicket_marks_ticket_with_current_utc_timestamp([Frozen] IEnvironment environment,
                                                                     DateTime now,
                                                                     TicketFactory sut,
                                                                     string title,
                                                                     string description,
                                                                     User user,
                                                                     TicketType type)
    {
      // Arrange
      Mock.Get(environment)
          .Setup(x => x.GetCurrentUtcTimestamp())
          .Returns(now);

      // Act
      var result = sut.CreateTicket(title, description, user, type);

      // Assert
      Assert.AreEqual(now, result.CreationTimestamp);
    }

    [Test,AutoMoqData]
    public void CreateTicket_adds_labels_to_ticket([Frozen] IGetsLabels labelProvider,
                                                   TicketFactory sut,
                                                   CreateTicketRequest request,
                                                   IEnumerable<Label> labels)
    {
      // Arrange
      Mock.Get(labelProvider)
          .Setup(x => x.GetLabels(request.CommaSeparatedLabelNames))
          .Returns(labels.ToArray());

      // Act
      var result = sut.CreateTicketForCurrentUser(request);

      // Assert
      Assert.That(result.Labels, Is.EquivalentTo(labels));
    }
  }
}
