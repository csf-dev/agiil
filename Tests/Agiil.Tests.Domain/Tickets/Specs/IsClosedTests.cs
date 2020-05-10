using System;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using Agiil.Tests.Attributes;
using NUnit.Framework;
using CSF.Specifications;

namespace Agiil.Tests.Tickets.Specs
{
  [TestFixture,Parallelizable]
  public class IsClosedTests
  {
    [Test,AutoMoqData]
    public void Matches_returns_true_for_a_ticket_which_is_closed(Ticket ticket)
    {
      // Arrange
      ticket.Closed = true;
      var sut = new IsClosed();

      // Act
      var result = sut.Matches(ticket);

      // Assert
      Assert.That(result, Is.True);
    }

    [Test,AutoMoqData]
    public void Matches_returns_false_for_a_ticket_which_is_open(Ticket ticket)
    {
      // Arrange
      ticket.Closed = false;
      var sut = new IsClosed();

      // Act
      var result = sut.Matches(ticket);

      // Assert
      Assert.That(result, Is.False);
    }
  }
}
