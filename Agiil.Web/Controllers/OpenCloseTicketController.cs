using System;
using System.Net;
using System.Web.Mvc;
using Agiil.Domain.Tickets;
using CSF.Entities;

namespace Agiil.Web.Controllers
{
    public class OpenCloseTicketController : Controller
    {
        readonly ITicketOpenerCloser openerCloser;
        readonly IGetsTicketReference referenceProvider;

        [HttpPost]
        public ActionResult Close(IIdentity<Ticket> id)
        {
            return OpenOrClose(id, identity => openerCloser.Close(new CloseTicketRequest { Identity = identity }));
        }

        [HttpPost]
        public ActionResult Reopen(IIdentity<Ticket> id)
        {
            return OpenOrClose(id, identity => openerCloser.Reopen(new ReopenTicketRequest { Identity = identity }));
        }

        ActionResult OpenOrClose(IIdentity<Ticket> id,
                                 Func<IIdentity<Ticket>, IOpenCloseTicketResponse> openOrCloseFunc)
        {
            if(ReferenceEquals(id, null))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = openOrCloseFunc(id);
            if(result.TicketNotFound) return HttpNotFound();

            return RedirectToAction(nameof(TicketController.Index),
                                    this.GetName<TicketController>(),
                                    new { id = referenceProvider.GetTicketReference(id) });
        }

        public OpenCloseTicketController(ITicketOpenerCloser openerCloser, IGetsTicketReference referenceProvider)
        {
            this.openerCloser = openerCloser ?? throw new ArgumentNullException(nameof(openerCloser));
            this.referenceProvider = referenceProvider ?? throw new ArgumentNullException(nameof(referenceProvider));
        }
    }
}
