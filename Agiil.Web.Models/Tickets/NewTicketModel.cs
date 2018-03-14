using System;
using System.Collections.Generic;
using Agiil.Web.Models.Shared;
using Agiil.Web.Models.Sprints;

namespace Agiil.Web.Models.Tickets
{
  public class NewTicketModel : PageModel
  {
    public NewTicketSpecification Specification { get; set; }

    public NewTicketResponse Response { get; set; }

    public IList<SprintSummaryDto> AvailableSprints { get; set; }

    public IList<TicketTypeDto> AvailableTicketTypes { get; set; }

    public NewTicketModel()
    {
      Specification = new NewTicketSpecification();
    }
  }
}
