using System;
using Agiil.Domain.Tickets;

namespace Agiil.Domain.Tickets
{
  public interface ITicketCreator
  {
    Ticket Create(CreateTicketRequest request);
  }
}
