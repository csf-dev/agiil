using System;
using System.Web.Mvc;
using System.Web.Routing;
using Agiil.Domain;
using Agiil.Domain.Tickets;
using Agiil.Web.Controllers;
using Agiil.Web.Rendering.Tickets;
using CSF.Entities;

namespace Agiil.Web.Services.Rendering
{
  public class TicketUriProvider : IGetsTicketUri
  {
    readonly ITicketReferenceQuery ticketReferenceQuery;
    readonly UrlHelper urlHelper;
    readonly IProvidesApplicationBaseUri baseUriProvider;

    public Uri GetAbsoluteUri(TicketReference ticketRef)
    {
      var ticket = ticketReferenceQuery.GetTicketByReference(ticketRef);
      return GetAbsoluteUri(ticket?.GetIdentity());
    }

    public Uri GetAbsoluteUri(IIdentity<Ticket> ticketIdentity)
    {
      if(ticketIdentity == null) return null;
      var builder = new UriBuilder(baseUriProvider.GetBaseUri());

      builder.Path = urlHelper.Action(nameof(TicketController.Index),
                                      typeof(TicketController).AsControllerName(),
                                      new { id = ticketIdentity });

      return builder.Uri;
    }

    public Uri GetRelativeUri(TicketReference ticketRef)
    {
      var ticket = ticketReferenceQuery.GetTicketByReference(ticketRef);
      return GetRelativeUri(ticket?.GetIdentity());
    }

    public Uri GetRelativeUri(IIdentity<Ticket> ticketIdentity)
    {
      if(ticketIdentity == null) return null;
      var builder = new UriBuilder();

      builder.Path = urlHelper.Action(nameof(TicketController.Index),
                                      typeof(TicketController).AsControllerName(),
                                      new { id = ticketIdentity });

      return builder.Uri;
    }

    public TicketUriProvider(ITicketReferenceQuery ticketReferenceQuery,
                             UrlHelper urlHelper,
                             IProvidesApplicationBaseUri baseUriProvider)
    {
      if(baseUriProvider == null)
        throw new ArgumentNullException(nameof(baseUriProvider));
      if(urlHelper == null)
        throw new ArgumentNullException(nameof(urlHelper));
      if(ticketReferenceQuery == null)
        throw new ArgumentNullException(nameof(ticketReferenceQuery));
      
      this.ticketReferenceQuery = ticketReferenceQuery;
      this.urlHelper = urlHelper;
      this.baseUriProvider = baseUriProvider;
    }
  }
}
