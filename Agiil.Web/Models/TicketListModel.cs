using System;
using System.Collections.Generic;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.Models
{
  public class TicketListModel : StandardPageModel
  {
    public bool ShowingClosedTickets { get; set; }

    public IList<TicketSummaryDto> Tickets { get; set; }
  }
}
