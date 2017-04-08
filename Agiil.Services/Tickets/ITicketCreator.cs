using System;
using Agiil.Domain.Tickets;

namespace Agiil.Services.Tickets
{
  public interface ITicketCreator
  {
    Ticket Create(CreateTicketRequest request);
  }
}
