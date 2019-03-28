using System;
using Agiil.Domain.Activity;
using Agiil.Domain.Tickets;
using Agiil.Tests.Attributes;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Activity
{
  [TestFixture,Parallelizable]
  public class TicketWorkLogFactoryTests
  {
    [Test,AutoMoqData]
    public void GetWorkLog_throws_ArgumentException_if_user_is_null(AddWorkLogRequest request,
                                                                    TicketWorkLogFactory sut)
    {
      request.User = null;
      Assert.That(() => sut.GetWorkLog(request), Throws.InstanceOf<ArgumentException>());
    }

    [Test,AutoMoqData]
    public void GetWorkLog_returns_failure_result_if_time_parser_throws_FormatException(AddWorkLogRequest request,
                                                                                        [Frozen] IParsesTimespan timespanParser,
                                                                                        TicketWorkLogFactory sut)
    {
      Mock.Get(timespanParser).Setup(x => x.GetTimeSpan(It.IsAny<string>())).Throws<FormatException>();
      var result = sut.GetWorkLog(request);

      Assert.That(result?.Success, Is.False);
      Assert.That(result?.TimeSpentIsInvalid, Is.True);
    }

    [Test,AutoMoqData]
    public void GetWorkLog_returns_failure_result_if_ticket_query_returns_null(AddWorkLogRequest request,
                                                                               [Frozen] ITicketReferenceQuery ticketQuery,
                                                                               TicketWorkLogFactory sut)
    {
      Mock.Get(ticketQuery).Setup(x => x.GetTicketByReference(It.IsAny<string>())).Returns(() => null);
      var result = sut.GetWorkLog(request);

      Assert.That(result?.Success, Is.False);
      Assert.That(result?.TicketNotFound, Is.True);
    }

    [Test,AutoMoqData]
    public void GetWorkLog_returns_success_result_with_correct_values_from_services(AddWorkLogRequest request,
                                                                                    [Frozen] IParsesTimespan timespanParser,
                                                                                    [Frozen] ITicketReferenceQuery ticketQuery,
                                                                                    int minutes,
                                                                                    Ticket ticket,
                                                                                    TicketWorkLogFactory sut)
    {
      Mock.Get(ticketQuery).Setup(x => x.GetTicketByReference(request.TicketReference)).Returns(ticket);
      Mock.Get(timespanParser).Setup(x => x.GetTimeSpan(request.TimeSpent)).Returns(() => TimeSpan.FromMinutes(minutes));

      var result = sut.GetWorkLog(request);

      Assert.That(result?.Success, Is.True);
      Assert.That(result?.WorkLog?.User, Is.SameAs(request.User));
      Assert.That(result?.WorkLog?.Ticket, Is.SameAs(ticket));
      Assert.That(result?.WorkLog?.TimeSpent.TotalMinutes, Is.EqualTo(minutes));
      Assert.That(result?.WorkLog?.TimeStarted, Is.EqualTo(request.TimeStarted));
    }
  }
}
