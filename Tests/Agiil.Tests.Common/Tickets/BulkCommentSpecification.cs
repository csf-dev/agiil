using System;
using Agiil.Domain.Tickets;
using CSF.Entities;

namespace Agiil.Tests.Tickets
{
  public class BulkCommentSpecification
  {
    public long TicketId { get; set; }

    public IIdentity<Ticket> TicketIdentity => Identity.Create<Ticket>(TicketId);

    public long? Id { get; set; }

    public string Author { get; set; }

    public string Body { get; set; }

    public DateTime Timestamp { get; set; }
  }
}
