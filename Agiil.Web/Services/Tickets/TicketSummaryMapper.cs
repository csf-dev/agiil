using System.Collections.Generic;
using System.Linq;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using CSF.Entities;

namespace Agiil.Web.Services.Tickets
{
  public class TicketSummaryMapper
  {
    public IList<TicketSummaryDto> Map(IList<Ticket> tickets)
    {
      if(tickets == null)
        return null;

      return tickets.Select(Map).ToList();
    }

    public TicketSummaryDto Map(Ticket ticket)
    {
      if(ticket == null)
        return null;

      var id = ticket.GetIdentity();

      return new TicketSummaryDto {
        Id = (long) ((id != null) ? id.Value : default(long)),
        Title = ticket.Title,
        Creator = ticket.User.Username,
        Created = ticket.CreationTimestamp,
        Reference = ticket.GetTicketReference(),
        Closed = ticket.Closed,
      };
    }
  }
}
