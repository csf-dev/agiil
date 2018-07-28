using System;
using System.Collections.Generic;

namespace Agiil.Domain.Tickets
{
  public interface IGetsListOfTickets
  {
    IReadOnlyList<Ticket> GetTickets(TicketListRequest request);
  }
}
