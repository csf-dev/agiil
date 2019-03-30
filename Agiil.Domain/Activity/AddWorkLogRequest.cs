using System;
using Agiil.Domain.Auth;

namespace Agiil.Domain.Activity
{
  public class AddWorkLogRequest
  {
    public string TimeSpent { get; set; }

    public DateTime TimeStarted { get; set; }
  
    public string TicketReference { get; set; }

    public User User { get; set; }
  }
}
