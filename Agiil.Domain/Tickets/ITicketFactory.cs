using System;
using Agiil.Domain.Auth;

namespace Agiil.Domain.Tickets
{
  public interface ITicketFactory
  {
    Ticket CreateTicketForCurrentUser(CreateTicketRequest request);

    Ticket CreateTicket(CreateTicketRequest request, User creator);
  }
}
