using System;
using System.Collections.Generic;
using Agiil.Domain.Tickets;

namespace Agiil.Domain.Labels
{
  public interface IGetsTicketsWithLabel
  {
    IReadOnlyCollection<Ticket> GetAllOpenTickets(string labelName);
    IReadOnlyCollection<Ticket> GetAllOpenTickets(Label label);

    IReadOnlyCollection<Ticket> GetAllClosedTickets(string labelName);
    IReadOnlyCollection<Ticket> GetAllClosedTickets(Label label);
  }
}
