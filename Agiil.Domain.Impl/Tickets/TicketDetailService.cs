using System;
using System.Linq;
using CSF.Entities;
using CSF.ORM;

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
        .FetchChildren(x => x.Comments)
        .FetchChild(x => x.Type)
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
