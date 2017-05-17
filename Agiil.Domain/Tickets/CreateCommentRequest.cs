using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class CreateCommentRequest
  {
    public IIdentity<Ticket> TicketId { get; set; }

    public string Body { get; set; }
  }
}
