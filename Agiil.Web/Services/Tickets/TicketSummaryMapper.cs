using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Domain.Tickets;
using Agiil.Web.Models;

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
      
      return new TicketSummaryDto {
        Title = ticket.Title,
        Creator = ticket.User.Username,
        Created = ticket.CreationTimestamp,
      };
    }
  }
}
