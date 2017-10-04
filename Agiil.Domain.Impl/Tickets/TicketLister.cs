using System;
using System.Collections.Generic;
using System.Linq;
using CSF.Data.Entities;
using CSF.Data.NHibernate;

namespace Agiil.Domain.Tickets
{
  public class TicketLister : ITicketLister
  {
    readonly IEntityData ticketRepo;

    public IList<Ticket> GetTickets()
    {
      return GetTickets(TicketListRequest.CreateDefault());
    }

    public IList<Ticket> GetTickets(TicketListRequest request)
    {
      var query = GetQuery();
      query = ConfigureQuery(query, request);

      return query
        .Fetch(x => x.User)
        .Fetch(x => x.Type)
        .ToList();
    }

    IQueryable<Ticket> GetQuery()
    {
      return ticketRepo.Query<Ticket>();
    }

    IQueryable<Ticket> ConfigureQuery(IQueryable<Ticket> query, TicketListRequest request)
    {
      if(!request.ShowClosedTickets)
      {
        query = query.Where(x => !x.Closed);
      }

      if(!request.ShowOpenTickets)
      {
        query = query.Where(x => x.Closed);
      }

      query = query.OrderByDescending(x => x.CreationTimestamp);

      return query;
    }

    public TicketLister(IEntityData ticketRepo)
    {
      if(ticketRepo == null)
        throw new ArgumentNullException(nameof(ticketRepo));
      
      this.ticketRepo = ticketRepo;
    }
  }
}
