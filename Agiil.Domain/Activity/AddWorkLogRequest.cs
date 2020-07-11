using System;
using Agiil.Domain.Auth;
using Agiil.Domain.Tickets;

namespace Agiil.Domain.Activity
{
  public class AddWorkLogRequest
  {
    public string TimeSpent { get; set; }

    public DateTime TimeStarted { get; set; }
  
    public TicketReference TicketReference { get; set; }

    public User User { get; set; }
  }
}
