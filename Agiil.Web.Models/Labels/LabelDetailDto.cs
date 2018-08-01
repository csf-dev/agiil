using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Web.Models.Tickets;

namespace Agiil.Web.Models.Labels
{
  public class LabelDetailDto : LabelDto
  {
    public IReadOnlyCollection<TicketSummaryDto> OpenTickets { get; set; }

    public IReadOnlyCollection<TicketSummaryDto> ClosedTickets { get; set; }
  }
}
