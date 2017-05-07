﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agiil.Domain.Tickets;
using Agiil.Web.Models;
using Agiil.Web.Services.Tickets;

namespace Agiil.Web.Controllers
{
  public class TicketsController : ControllerBase
  {
    readonly ITicketLister lister;
    readonly TicketSummaryMapper mapper;

    public ActionResult Index()
    {
      var tickets = lister.GetTickets();
      var model = new TicketListModel
      {
        Tickets = mapper.Map(tickets)
      };
      return View (model);
    }

    public TicketsController(ITicketLister lister,
                             TicketSummaryMapper mapper)
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
