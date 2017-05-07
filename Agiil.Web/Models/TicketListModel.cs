using System;
using System.Collections.Generic;

namespace Agiil.Web.Models
{
  public class TicketListModel
  {
    public IList<TicketSummaryDto> Tickets { get; set; }
  }
}
