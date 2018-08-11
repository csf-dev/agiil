using System;
using System.Linq;

namespace Agiil.Domain.Tickets
{
  public interface IGetsQueryForTickets
  {
    IQueryable<Ticket> GetQuery();
  }
}
