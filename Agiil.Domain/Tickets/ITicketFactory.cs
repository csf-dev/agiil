using System;
using Agiil.Domain.Auth;
using Agiil.Domain.Tickets;

namespace Agiil.Domain.Tickets
{
  public interface ITicketFactory
  {
    Ticket CreateTicket(string title, string description, User creator, TicketType type);
  }
}
