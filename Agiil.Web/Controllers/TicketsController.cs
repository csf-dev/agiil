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
    readonly IGetsListOfTicketsFromAgiilQuery lister;
    readonly IMapper mapper;

    public ActionResult Index(string q)
    {
      var model = GetModel(q);
      return View (model);
    }

    TicketListModel GetModel(string agiilQuery)
    {
      if(String.IsNullOrEmpty(agiilQuery))
        agiilQuery = "ticket is open";
      
      var model = new TicketListModel { Query = agiilQuery };

      var tickets = lister.GetTickets(agiilQuery);
      if(tickets != null)
        model.Tickets = tickets.Select(mapper.Map<TicketSummaryDto>).ToList();

      return model;
    }

    public TicketsController(IGetsListOfTicketsFromAgiilQuery lister, IMapper mapper)
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
