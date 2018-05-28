using System;
namespace Agiil.Web.Rendering.Tickets
{
  /// <summary>
  /// Service which gets the URI to a ticket's main "view this ticket detail" web page.
  /// </summary>
  public interface IGetsTicketUri
  {
    Uri GetRelativeUri(string ticketReference);

    Uri GetRelativeUri(long ticketId);

    Uri GetAbsoluteUri(string ticketReference);

    Uri GetAbsoluteUri(long ticketId);
  }
}
