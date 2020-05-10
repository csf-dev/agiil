using System;

namespace Agiil.Domain.Tickets
{
  public interface IGetsTicketUris
  {
    Uri GetViewTicketUri(TicketReference reference);
    Uri GetEditTicketUri(TicketReference reference);
  }
}
