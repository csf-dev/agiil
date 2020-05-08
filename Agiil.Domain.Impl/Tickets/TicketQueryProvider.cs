using System;
using System.Linq;
using CSF.ORM;

namespace Agiil.Domain.Tickets
{
  public class TicketQueryProvider : IGetsQueryForTickets
  {
    readonly IEntityData data;

    public IQueryable<Ticket> GetQuery() => data.Query<Ticket>();

    public TicketQueryProvider(IEntityData data)
    {
      if(data == null)
        throw new ArgumentNullException(nameof(data));
      
      this.data = data;
    }
  }
}
