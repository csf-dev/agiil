using System;
using System.Collections.Generic;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.Models.Tickets
{
  public class TicketListModel : PageModel
  {
    public bool ShowingClosedTickets { get; set; }

    public IList<TicketSummaryDto> Tickets { get; set; }
  }
}
