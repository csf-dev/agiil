using System;
using System.Collections.Generic;
using Agiil.Domain.Tickets;

namespace Agiil.Domain.Sprints
{
  public interface IGetsTicketsInSprint
  {
    IReadOnlyCollection<Ticket> GetAllOpenTickets(string sprintName);
    IReadOnlyCollection<Ticket> GetAllOpenTickets(Sprint sprint);

    IReadOnlyCollection<Ticket> GetAllClosedTickets(string sprintName);
    IReadOnlyCollection<Ticket> GetAllClosedTickets(Sprint sprint);
  }
}
