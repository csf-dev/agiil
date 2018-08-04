using System;
namespace Agiil.Domain.Tickets.Creation
{
  public interface IGetsTicketCreator
  {
    ICreatesTicket GetTicketCreator();
  }
}
