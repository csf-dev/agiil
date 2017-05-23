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
      // TODO: Add a fetch for the comments to prevent SELECT N+1
      // Right now this isn't working though, not sure if it's my bad with the mapping or CSF.Data.NHibernate at fault
    }

    public TicketDetailService(IRepository<Ticket> repo)
    {
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      this.repo = repo;
    }
  }
}
