using System;
using System.Web.Mvc;
using Agiil.Domain;
using Agiil.Domain.Tickets;
using Agiil.Web.Controllers;
using Agiil.Web.Models.Tickets;
using Agiil.Web.Rendering.Tickets;
using CSF.Entities;

namespace Agiil.Web.Services.Rendering
{
  public class RenderingTicketUriProviderAdapter : IGetsTicketUri
  {
    readonly IGetsTicketUris wrappedUriProvider;

    public Uri GetAbsoluteUri(TicketReference ticketRef)
    {
      return wrappedUriProvider.GetViewTicketUri(ticketRef);
    }

    public RenderingTicketUriProviderAdapter(IGetsTicketUris wrappedUriProvider)
    {
      if(wrappedUriProvider == null)
        throw new ArgumentNullException(nameof(wrappedUriProvider));
      this.wrappedUriProvider = wrappedUriProvider;
    }
  }
}
