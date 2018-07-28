using System;
using System.Collections.Generic;

namespace Agiil.Domain.Tickets
{
  public interface IGetsListOfTicketsFromAgiilQuery
  {
    IReadOnlyList<Ticket> GetTickets(string agiilQueryString);
  }
}
