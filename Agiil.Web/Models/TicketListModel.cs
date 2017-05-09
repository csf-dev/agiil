using System;
using System.Collections.Generic;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.Models
{
  public class TicketListModel : StandardPageModel
  {
    public IList<TicketSummaryDto> Tickets { get; set; }
  }
}
