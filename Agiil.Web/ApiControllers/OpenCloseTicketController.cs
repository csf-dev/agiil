using System;
using System.Web.Http;
using Agiil.Domain.Tickets;
using CSF.Entities;

namespace Agiil.Web.ApiControllers
{
  public class OpenCloseTicketController : ApiController
  {
    readonly ITicketOpenerCloser openerCloser;

    [HttpPost]
    public IHttpActionResult Close(IIdentity<Ticket> id)
    {
      if(ReferenceEquals(id, null))
        return BadRequest();

      var request = new CloseTicketRequest { Identity = id };
      var result = openerCloser.Close(request);

      if(result.TicketNotFound)
      {
        return NotFound();
      }

      return Ok();
    }

    [HttpPost]
    public IHttpActionResult Reopen(IIdentity<Ticket> id)
    {
      if(ReferenceEquals(id, null))
        return BadRequest();

      var request = new ReopenTicketRequest { Identity = id };
      var result = openerCloser.Reopen(request);

      if(result.TicketNotFound)
      {
        return NotFound();
      }

      return Ok();
    }

    public OpenCloseTicketController(ITicketOpenerCloser openerCloser)
    {
      if(openerCloser == null)
        throw new ArgumentNullException(nameof(openerCloser));

      this.openerCloser = openerCloser;
    }
  }
}
