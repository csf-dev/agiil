using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Agiil.Domain.Tickets;
using CSF.Entities;

namespace Agiil.Web.Controllers
{
  public class OpenCloseTicketController : Controller
  {
    readonly ITicketOpenerCloser openerCloser;

    [HttpPost]
    public ActionResult Close(IIdentity<Ticket> id)
    {
      if(ReferenceEquals(id, null))
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      
      var request = new CloseTicketRequest { Identity = id };
      var result = openerCloser.Close(request);

      if(result.TicketNotFound)
      {
        return HttpNotFound();
      }

      return RedirectToAction(nameof(TicketController.Index),
                              this.GetName<TicketController>(),
                              new { id = id.Value });
    }

    [HttpPost]
    public ActionResult Reopen(IIdentity<Ticket> id)
    {
      if(ReferenceEquals(id, null))
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      var request = new ReopenTicketRequest { Identity = id };
      var result = openerCloser.Reopen(request);

      if(result.TicketNotFound)
      {
        return HttpNotFound();
      }

      return RedirectToAction(nameof(TicketController.Index),
                              this.GetName<TicketController>(),
                              new { id = id.Value });
    }

    public OpenCloseTicketController(ITicketOpenerCloser openerCloser)
    {
      if(openerCloser == null)
        throw new ArgumentNullException(nameof(openerCloser));

      this.openerCloser = openerCloser;
    }
  }
}
