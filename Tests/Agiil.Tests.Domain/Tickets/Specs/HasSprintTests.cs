using System;
using Agiil.Domain.Labels;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using Agiil.Tests.Attributes;
using NUnit.Framework;

namespace Agiil.Tests.Tickets.Specs
{
  [TestFixture,Parallelizable]
  public class HasSprintTests
  {
    [Test,AutoMoqData]
    public void Matches_returns_true_for_a_ticket_which_has_a_sprint_with_a_matching_name(Ticket ticket, Sprint sprint)
    {
      // Arrange
      var sprintNameOne = "one";
      var sprintNameTwo = "two";
      ticket.Sprint = sprint;
      ticket.Sprint.Name = sprintNameOne;
      var sut = new HasSprint(sprintNameOne, sprintNameTwo);

      // Act
      var result = sut.Matches(ticket);

      // Assert
      Assert.That(result, Is.True);
    }

    [Test,AutoMoqData]
    public void Matches_returns_false_for_a_ticket_which_has_no_sprint(Ticket ticket)
    {
      // Arrange
      var sprintNameOne = "one";
      var sprintNameTwo = "two";
      ticket.Sprint = null;
      var sut = new HasSprint(sprintNameOne, sprintNameTwo);

      // Act
      var result = sut.Matches(ticket);

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void Matches_returns_false_for_a_ticket_which_has_a_non_matching_sprint(Ticket ticket, Sprint sprint)
    {
      // Arrange
      var sprintNameOne = "one";
      var sprintNameTwo = "two";
      ticket.Sprint = sprint;
      ticket.Sprint.Name = "three";
      var sut = new HasSprint(sprintNameOne, sprintNameTwo);

      // Act
      var result = sut.Matches(ticket);

      // Assert
      Assert.That(result, Is.False);
    }
  }
}
