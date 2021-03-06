﻿using System;
using Agiil.Domain.Labels;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using Agiil.Tests.Attributes;
using NUnit.Framework;
using CSF.Specifications;

namespace Agiil.Tests.Tickets.Specs
{
  [TestFixture,Parallelizable]
  public class HasAllLabelsTests
  {
    [Test,AutoMoqData]
    public void Matches_returns_true_for_a_ticket_which_has_both_named_labels(Ticket ticket)
    {
      // Arrange
      var labeNameOne = "one";
      var labeNameTwo = "two";
      ticket.Labels.Add(new Label { Name = labeNameOne });
      ticket.Labels.Add(new Label { Name = labeNameTwo });
      var sut = new HasAllLabels(labeNameOne, labeNameTwo);

      // Act
      var result = sut.Matches(ticket);

      // Assert
      Assert.That(result, Is.True);
    }

    [Test,AutoMoqData]
    public void Matches_returns_true_for_a_ticket_which_has_both_named_labels_and_more(Ticket ticket,
                                                                                       string anotherLabelName)
    {
      // Arrange
      var labeNameOne = "one";
      var labeNameTwo = "two";
      ticket.Labels.Add(new Label { Name = labeNameOne });
      ticket.Labels.Add(new Label { Name = labeNameTwo });
      ticket.Labels.Add(new Label { Name = anotherLabelName });
      var sut = new HasAllLabels(labeNameOne, labeNameTwo);

      // Act
      var result = sut.Matches(ticket);

      // Assert
      Assert.That(result, Is.True);
    }

    [Test,AutoMoqData]
    public void Matches_returns_false_for_a_ticket_which_has_only_one_named_label(Ticket ticket)
    {
      // Arrange
      var labeNameOne = "one";
      var labeNameTwo = "two";
      ticket.Labels.Add(new Label { Name = labeNameOne });
      var sut = new HasAllLabels(labeNameOne, labeNameTwo);

      // Act
      var result = sut.Matches(ticket);

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void Matches_returns_false_for_a_ticket_which_has_no_labels(Ticket ticket)
    {
      // Arrange
      var labeNameOne = "one";
      var labeNameTwo = "two";
      ticket.Labels.Clear();
      var sut = new HasAllLabels(labeNameOne, labeNameTwo);

      // Act
      var result = sut.Matches(ticket);

      // Assert
      Assert.That(result, Is.False);
    }
  }
}
