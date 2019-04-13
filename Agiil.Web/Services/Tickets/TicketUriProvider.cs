using System;
using System.Web.Mvc;
using Agiil.Domain.Tickets;
using Agiil.Web.Controllers;

namespace Agiil.Web.Services.Tickets
{
  public class TicketUriProvider : IGetsTicketUris
  {
    readonly UrlHelper helper;

    public Uri GetEditTicketUri(TicketReference reference)
    {
      if(reference == null) return null;
      var uriString = helper.Action(nameof(TicketController.Edit),
                                    typeof(TicketController).AsControllerName(),
                                    reference);
      return new Uri(uriString);
    }

    public Uri GetViewTicketUri(TicketReference reference)
    {
      if(reference == null) return null;
      var uriString = helper.Action(nameof(TicketController.Index),
                                    typeof(TicketController).AsControllerName(),
                                    reference);
      return new Uri(uriString);
    }

    public TicketUriProvider(UrlHelper helper)
    {
      if(helper == null)
        throw new ArgumentNullException(nameof(helper));
      this.helper = helper;
    }
  }
}
