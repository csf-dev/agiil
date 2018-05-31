using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Web.Models.Tickets;

namespace Agiil.Web.Models.Labels
{
  public class LabelDetailDto : LabelDto
  {
    public ICollection<TicketSummaryDto> Tickets { get; set; }

    public IReadOnlyCollection<TicketSummaryDto> OpenTickets => Tickets.Where(x => !x.Closed).ToArray();

    public IReadOnlyCollection<TicketSummaryDto> ClosedTickets => Tickets.Where(x => x.Closed).ToArray();
  }
}
