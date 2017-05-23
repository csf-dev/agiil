using System;
using System.Collections.Generic;

namespace Agiil.Domain.Tickets
{
  public interface ITicketLister
  {
    IList<Ticket> GetTickets();

    IList<Ticket> GetTickets(TicketListRequest request);
  }
}
