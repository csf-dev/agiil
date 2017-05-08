using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agiil.Domain.Tickets;
using Agiil.Web.Models;
using Agiil.Web.Services.Tickets;
using CSF.Entities;

namespace Agiil.Web.Controllers
{
  public class TicketController : ControllerBase
  {
    readonly ITicketDetailService ticketDetailService;
    readonly TicketDetailMapper mapper;

    public ActionResult Index(IIdentity<Ticket> id)
    {
      var ticket = ticketDetailService.GetTicket(id);

      if(ReferenceEquals(ticket, null))
        return HttpNotFound();

      var model = new TicketDetailModel
      {
        Ticket = mapper.Map(ticket),
      };

      return View (model);
    }

    public TicketController(ITicketDetailService ticketDetailService,
                            TicketDetailMapper mapper)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(ticketDetailService == null)
        throw new ArgumentNullException(nameof(ticketDetailService));
      
      this.ticketDetailService = ticketDetailService;
      this.mapper = mapper;
    }
  }
}
