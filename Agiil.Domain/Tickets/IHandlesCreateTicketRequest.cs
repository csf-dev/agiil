using System;
using Agiil.Domain.Tickets;

namespace Agiil.Domain.Tickets
{
  public interface IHandlesCreateTicketRequest
  {
    CreateTicketResponse Create(CreateTicketRequest request);
  }
}
