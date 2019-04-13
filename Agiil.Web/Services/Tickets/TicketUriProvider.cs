using System;
using System.Web.Mvc;
using Agiil.Domain;
using Agiil.Domain.Tickets;
using Agiil.Web.Controllers;
using Agiil.Web.Models.Tickets;
using log4net;

namespace Agiil.Web.Services.Tickets
{
  public class TicketUriProvider : IGetsTicketUris
  {
    readonly UrlHelper helper;
    readonly ILog logger;
    readonly IProvidesApplicationBaseUri baseUriProvider;

    public Uri GetEditTicketUri(TicketReference reference)
    {
      if(reference == null) return null;
      var uriString = helper.Action(nameof(TicketController.Edit),
                                    typeof(TicketController).AsControllerName(),
                                    new { id = reference });
      logger.DebugFormat("Edit ticket URL:{0}", uriString);
      return new Uri(baseUriProvider.GetBaseUri(), uriString);
    }

    public Uri GetViewTicketUri(TicketReference reference)
    {
      if(reference == null) return null;
      var uriString = helper.Action(nameof(TicketController.Index),
                                    typeof(TicketController).AsControllerName(),
                                    new { id = reference });
      logger.DebugFormat("View ticket URL:{0}", uriString);
      return new Uri(baseUriProvider.GetBaseUri(), uriString);
    }

    public TicketUriProvider(UrlHelper helper, ILog logger, IProvidesApplicationBaseUri baseUriProvider)
    {
      if(baseUriProvider == null)
        throw new ArgumentNullException(nameof(baseUriProvider));
      if(logger == null)
        throw new ArgumentNullException(nameof(logger));
      if(helper == null)
        throw new ArgumentNullException(nameof(helper));
      this.helper = helper;
      this.logger = logger;
      this.baseUriProvider = baseUriProvider;
    }
  }
}
