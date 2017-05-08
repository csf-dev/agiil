using System;
using Agiil.Domain.Tickets;
using Agiil.Web.Models;
using CSF.Entities;

namespace Agiil.Web.Services.Tickets
{
  public class TicketDetailMapper
  {
    public TicketDetailDto Map(Ticket ticket)
    {
      if(ticket == null)
        return null;

      var id = ticket.GetIdentity();

      return new TicketDetailDto {
        Id = (long) ((id != null)? id.Value : default(long)),
        Title = ticket.Title,
        Description = ticket.Description,
        Creator = ticket.User.Username,
        Created = ticket.CreationTimestamp,
      };
    }
  }
}
