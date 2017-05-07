using System;
using System.Collections.Generic;
using System.Linq;
using CSF.Data.Entities;
using CSF.Data.NHibernate;

namespace Agiil.Domain.Tickets
{
  public class TicketLister : ITicketLister
  {
    readonly IRepository<Ticket> ticketRepo;

    public IList<Ticket> GetTickets()
    {
      return ticketRepo
        .Query()
        .OrderByDescending(x => x.CreationTimestamp)
        .Fetch(x => x.User)
        .ToList();
    }

    public TicketLister(IRepository<Ticket> ticketRepo)
    {
      if(ticketRepo == null)
        throw new ArgumentNullException(nameof(ticketRepo));
      
      this.ticketRepo = ticketRepo;
    }
  }
}
