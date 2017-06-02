using System;
using System.Collections.Generic;
using Agiil.Web.Models.Shared;
using Agiil.Web.Models.Sprints;

namespace Agiil.Web.Models.Tickets
{
  public class EditTicketModel : StandardPageModel
  {
    public TicketDetailDto  Ticket { get; set; }

    public IList<SprintSummaryDto> AvailableSprints { get; set; }

    public EditTicketSpecification Specification { get; set; }

    public EditTicketResponse Response { get; set; }

    public EditTicketModel()
    {
      Specification = new EditTicketSpecification();
    }
  }
}
