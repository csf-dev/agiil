using System;
using Agiil.Domain.Tickets;

namespace Agiil.Web.Models.Sprints
{
  public class ViewSprintModel : PageModel
  {
    public SprintDetailDto Sprint { get; set; }
    public ITicketReferenceParser TicketReferenceParser { get; set; }
  }
}
