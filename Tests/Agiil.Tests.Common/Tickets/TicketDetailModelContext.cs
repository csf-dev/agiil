using System;
using Agiil.Web.Models;
using Agiil.Web.Models.Tickets;

namespace Agiil.Tests.Tickets
{
  public class TicketDetailModelContext
  {
    public bool NotFound { get; set; }

    public TicketDetailModel Model { get; set; }
  }
}
