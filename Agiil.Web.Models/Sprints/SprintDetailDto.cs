using System;
using System.Collections.Generic;
using Agiil.Web.Models.Tickets;

namespace Agiil.Web.Models.Sprints
{
  public class SprintDetailDto : SprintDtoBase
  {
    public string Description { get; set; }
    public string HtmlDescription { get; set; }

    public string ProjectName { get; set; }

    public string ProjectCode { get; set; }

    public DateTime CreationDate { get; set; }

    public string GetShortCreationDate() => CreationDate.ToString("D");

    public IEnumerable<TicketSummaryDto> OpenTickets { get; set; }

    public IEnumerable<TicketSummaryDto> ClosedTickets { get; set; }
  }
}
