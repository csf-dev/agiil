using System;
using Agiil.Domain.Tickets;

namespace Agiil.Web.Models.Activity
{
  public class AddTicketWorkLogModel : PageModel
  {
    public string TimeSpent { get; set; }

    public DateTime TimeStarted { get; set; }

    public TicketReference TicketReference { get; set; }

    public bool InvalidTime { get; set; }

    public bool InvalidTicket { get; set; }
  }
}
