using System;
using Agiil.Domain.Labels;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using Agiil.Tests.Attributes;
using NUnit.Framework;
using CSF.Specifications;

namespace Agiil.Tests.Tickets.Specs
{
  [TestFixture,Parallelizable]
  public class HasNoSprintTests
  {
    [Test,AutoMoqData]
    public void Matches_returns_true_for_a_ticket_which_has_no_sprint(Ticket ticket)
    {
      // Arrange
      ticket.Sprint = null;
      var sut = new HasNoSprint();

      // Act
      var result = sut.Matches(ticket);

      // Assert
      Assert.That(result, Is.True);
    }

    [Test,AutoMoqData]
    public void Matches_returns_true_for_a_ticket_which_has_a_sprint(Ticket ticket, Sprint sprint)
    {
      // Arrange
      ticket.Sprint = sprint;
      var sut = new HasNoSprint();

      // Act
      var result = sut.Matches(ticket);

      // Assert
      Assert.That(result, Is.False);
    }
  }
}
