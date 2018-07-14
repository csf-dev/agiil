using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.Web.Controllers
{
  public class TicketsController : Controller
  {
    readonly IGetsListOfTickets lister;
    readonly IMapper mapper;

    public ActionResult Index(AdHocTicketListSpecification spec)
    {
      var request = mapper.Map<TicketListRequest>(spec);
      var model = GetModel(request);
      return View (model);
    }

    TicketListModel GetModel(TicketListRequest listRequest)
    {
      var model = mapper.Map<TicketListModel>(listRequest);

      var tickets = lister.GetTickets(listRequest);
      if(tickets != null)
        model.Tickets = tickets.Select(x => mapper.Map<TicketSummaryDto>(x)).ToList();

      return model;
    }

    public TicketsController(IGetsListOfTickets lister, IMapper mapper)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(lister == null)
        throw new ArgumentNullException(nameof(lister));
      this.mapper = mapper;
      this.lister = lister;
    }
  }
}
