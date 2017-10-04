using System;
using System.Linq;
using CSF.Data.Entities;
using CSF.Data.NHibernate;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class TicketDetailService : ITicketDetailService
  {
    readonly IEntityData repo;

    public Ticket GetTicket(IIdentity<Ticket> ticket)
    {
      if(ticket == null)
      {
        throw new ArgumentNullException(nameof(ticket));
      }

      var ticketTheory = repo.Theorise(ticket);
      return repo
        .Query<Ticket>()
        .Where(x => x == ticketTheory)
        .FetchMany(x => x.Comments)
        .Fetch(x => x.Type)
        .ToArray()
        .FirstOrDefault();
    }

    public TicketDetailService(IEntityData repo)
    {
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      this.repo = repo;
    }
  }
}
