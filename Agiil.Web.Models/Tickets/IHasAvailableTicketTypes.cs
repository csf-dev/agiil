using System;
using System.Collections.Generic;

namespace Agiil.Web.Models.Tickets
{
  public interface IHasAvailableTicketTypes
  {
    IList<TicketTypeDto> AvailableTicketTypes { get; set; }
  }
}
