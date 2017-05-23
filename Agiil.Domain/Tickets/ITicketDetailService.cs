using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public interface ITicketDetailService
  {
    Ticket GetTicket(IIdentity<Ticket> ticket);
  }
}
