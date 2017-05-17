using System;
using System.Linq;
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
        Comments = ticket
          .Comments
          .OrderBy(x => x.CreationTimestamp)
          .Select(x => {
            var commentId = x.GetIdentity();
            return new CommentDto
            {
              Id = (commentId != null)? (long) commentId.Value : default(long),
              Timestamp = x.CreationTimestamp,
              Author = x.User.Username,
              Body = x.Body
            };
          })
          .ToArray()
      };
    }
  }
}
