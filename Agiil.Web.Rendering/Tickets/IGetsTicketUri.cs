using System;
using Agiil.Domain.Tickets;
using CSF.Entities;

namespace Agiil.Web.Rendering.Tickets
{
  /// <summary>
  /// Service which gets the URI to a ticket's main "view this ticket detail" web page.
  /// </summary>
  public interface IGetsTicketUri
  {
    Uri GetAbsoluteUri(TicketReference ticketRef);
  }
}
