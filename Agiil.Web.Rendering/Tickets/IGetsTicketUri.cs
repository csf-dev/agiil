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
    Uri GetRelativeUri(TicketReference ticketRef);

    Uri GetRelativeUri(IIdentity<Ticket> ticketIdentity);

    Uri GetAbsoluteUri(TicketReference ticketRef);

    Uri GetAbsoluteUri(IIdentity<Ticket> ticketIdentity);
  }
}
