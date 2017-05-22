using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class CloseTicketRequest
  {
    public IIdentity<Ticket> Identity { get; set; }
  }
}
