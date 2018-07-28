using System;
using Agiil.Domain.Labels;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using Agiil.Tests.Attributes;
using NUnit.Framework;

namespace Agiil.Tests.Tickets.Specs
{
  [TestFixture,Parallelizable]
  public class HasNoLabelsTests
  {
    [Test,AutoMoqData]
    public void Matches_returns_true_for_a_ticket_which_has_no_labels(Ticket ticket)
    {
      // Arrange
      ticket.Labels.Clear();
      var sut = new HasNoLabels();

      // Act
      var result = sut.Matches(ticket);

      // Assert
      Assert.That(result, Is.True);
    }

    [Test,AutoMoqData]
    public void Matches_returns_true_for_a_ticket_which_has_one_label(Ticket ticket, Label label)
    {
      // Arrange
      ticket.Labels.Clear();
      ticket.Labels.Add(label);
      var sut = new HasNoLabels();

      // Act
      var result = sut.Matches(ticket);

      // Assert
      Assert.That(result, Is.False);
    }
  }
}
