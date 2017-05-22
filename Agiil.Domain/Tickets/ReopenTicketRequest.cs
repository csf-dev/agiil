using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class ReopenTicketRequest
  {
    public IIdentity<Ticket> Identity { get; set; }
  }
}
