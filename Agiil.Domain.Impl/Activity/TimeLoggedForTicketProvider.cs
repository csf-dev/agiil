using System;
using Agiil.Domain.Tickets;
using CSF.Data.Entities;
using System.Linq;
using CSF.Data.Specifications;

namespace Agiil.Domain.Activity
{
  public class TimeLoggedForTicketProvider : IGetsSumOfLoggedWorkForTicket
  {
    readonly IEntityData data;
    readonly Func<Ticket, WorkLoggedForTicketSpecification> specFactory;

    public TimeLoggedForTicketProvider(IEntityData data, Func<Ticket, WorkLoggedForTicketSpecification> specFactory)
    {
      if(specFactory == null)
        throw new ArgumentNullException(nameof(specFactory));
      if(data == null)
        throw new ArgumentNullException(nameof(data));
      this.data = data;
      this.specFactory = specFactory;
    }

    public TimeSpan GetTotalTimeLogged(Ticket ticket)
    {
      if(ticket == null)
        throw new ArgumentNullException(nameof(ticket));

      var spec = specFactory(ticket);
      return data.Query<TicketWorkLog>()
                 .Where(spec)
                 .AsEnumerable()
                 .Aggregate(TimeSpan.Zero, (acc, next) => acc + next.GetTimeSpent());
    }
  }
}
