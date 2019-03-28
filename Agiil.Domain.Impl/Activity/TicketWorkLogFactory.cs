using System;
using Agiil.Domain.Tickets;

namespace Agiil.Domain.Activity
{
  public class TicketWorkLogFactory : IGetsTicketWorkLog
  {
    readonly IParsesTimespan timespanParser;
    readonly ITicketReferenceQuery ticketProvider;

    public GetWorklogResponse GetWorkLog(AddWorkLogRequest request)
    {
      if(request == null)
        throw new ArgumentNullException(nameof(request));
      if(request.User == null)
        throw new ArgumentException("User must not be null", nameof(request));

      TimeSpan time;

      try {
        time = timespanParser.GetTimeSpan(request.TimeSpent);
      }
      catch(FormatException ex) {
        return new GetWorklogResponse { Success = false, TimeSpentIsInvalid = true, };
      }

      var ticket = ticketProvider.GetTicketByReference(request.TicketReference);
      if(ticket == null)
        return new GetWorklogResponse { Success = false, TicketNotFound = true, };

      return new GetWorklogResponse {
        Success = true,
        WorkLog = new TicketWorkLog {
          User = request.User,
          TimeStarted = request.TimeStarted,
          TimeSpent = time,
          Ticket = ticket,
        }
      };
    }

    public TicketWorkLogFactory(IParsesTimespan timespanParser, ITicketReferenceQuery ticketProvider)
    {
      if(ticketProvider == null)
        throw new ArgumentNullException(nameof(ticketProvider));
      if(timespanParser == null)
        throw new ArgumentNullException(nameof(timespanParser));
      this.timespanParser = timespanParser;
      this.ticketProvider = ticketProvider;
    }
  }
}
