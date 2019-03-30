using System;
namespace Agiil.Web.Models.Activity
{
  public class AddTicketWorkLogModel : PageModel
  {
    public string TimeSpent { get; set; }

    public DateTime TimeStarted { get; set; }

    public string TicketReference { get; set; }

    public bool InvalidTime { get; set; }

    public bool InvalidTicket { get; set; }
  }
}
