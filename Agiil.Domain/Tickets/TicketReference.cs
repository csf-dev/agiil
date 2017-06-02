using System;
namespace Agiil.Domain.Tickets
{
  public class TicketReference
  {
    public string ProjectCode { get; private set; }

    public long TicketNumber { get; private set; }

    public TicketReference(string projectCode, long ticketNumber)
    {
      ProjectCode = projectCode;
      TicketNumber = ticketNumber;
    }
  }
}
