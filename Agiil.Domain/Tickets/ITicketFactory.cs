using System;
using Agiil.Domain.Auth;

namespace Agiil.Domain.Tickets
{
  public interface ITicketFactory
  {
    Ticket CreateTicketForCurrentUser(string title, string description, TicketType type);

    Ticket CreateTicket(string title, string description, User creator, TicketType type);
  }
}
