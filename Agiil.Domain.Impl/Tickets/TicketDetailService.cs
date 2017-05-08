using System;
using CSF.Data.Entities;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class TicketDetailService : ITicketDetailService
  {
    readonly IRepository<Ticket> repo;

    public Ticket GetTicket(IIdentity<Ticket> ticket)
    {
      if(ticket == null)
      {
        throw new ArgumentNullException(nameof(ticket));
      }

      return repo.Get(ticket);
    }

    public TicketDetailService(IRepository<Ticket> repo)
    {
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      this.repo = repo;
    }
  }
}
