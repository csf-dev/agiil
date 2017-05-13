using System;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.Models
{
  public class TicketDetailModel : StandardPageModel
  {
    public bool IsSuccessfulEdit { get; set; }

    public TicketDetailDto  Ticket { get; set; }
  }
}
