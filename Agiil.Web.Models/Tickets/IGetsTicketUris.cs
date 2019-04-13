using System;
using Agiil.Domain.Tickets;

namespace Agiil.Web.Models.Tickets
{
  public interface IGetsTicketUris
  {
    Uri GetViewTicketUri(TicketReference reference);
    Uri GetEditTicketUri(TicketReference reference);
  }
}
