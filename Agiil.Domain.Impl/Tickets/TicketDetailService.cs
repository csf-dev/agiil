using System;
using System.Linq;
using CSF.Data.Entities;
using CSF.Data.NHibernate;
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

      var ticketTheory = repo.Theorise(ticket);
      return repo
        .Query()
        .Where(x => x == ticketTheory)
        .FetchMany(x => x.Comments)
        .FirstOrDefault();
    }

    public TicketDetailService(IRepository<Ticket> repo)
    {
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      this.repo = repo;
    }
  }
}
