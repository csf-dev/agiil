using System;
using Agiil.Domain.Auth;

namespace Agiil.Domain.Tickets
{
  public interface ITicketFactory
  {
    [Obsolete("Instead, use an overload which takes a CreateTicketRequest")]
    Ticket CreateTicketForCurrentUser(string title, string description, TicketType type);

    [Obsolete("Instead, use an overload which takes a CreateTicketRequest")]
    Ticket CreateTicket(string title, string description, User creator, TicketType type);

    Ticket CreateTicketForCurrentUser(CreateTicketRequest request);

    Ticket CreateTicket(CreateTicketRequest request, User creator);
  }
}
