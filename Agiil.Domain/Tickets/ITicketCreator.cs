using System;
using Agiil.Domain.Tickets;

namespace Agiil.Domain.Tickets
{
  public interface ITicketCreator
  {
    CreateTicketResponse Create(CreateTicketRequest request);
  }
}
