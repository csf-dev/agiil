using System;
using Agiil.Domain.TicketSearch;

namespace Agiil.Domain.Tickets
{
  public class TicketListRequest
  {
    [Obsolete("Use the CriteriaModel property instead")]
    public bool ShowClosedTickets { get; set; }

    [Obsolete("Use the CriteriaModel property instead")]
    public bool ShowOpenTickets { get; set; }

    public SearchModel CriteriaModel { get; set; }

    public TicketListRequest()
    {
#pragma warning disable CS0618 // Type or member is obsolete
      ShowClosedTickets = false;
      ShowOpenTickets = true;
#pragma warning restore CS0618 // Type or member is obsolete
    }
  }
}
