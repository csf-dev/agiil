using System;
using Agiil.Domain.Tickets;

namespace Agiil.Web.Models.Sprints
{
  public class ViewSprintModel
  {
    public SprintDetailDto Sprint { get; set; }
    public IParsesTicketReference TicketReferenceParser { get; set; }
  }
}
