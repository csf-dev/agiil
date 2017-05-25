using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.Web.Controllers
{
  public class TicketsController : ControllerBase
  {
    readonly ITicketLister lister;
    readonly IMapper mapper;

    public ActionResult Index(AdHocTicketListSpecification spec)
    {
      var request = GetRequest(spec);
      var tickets = lister.GetTickets(request);
      var model = GetModel(tickets, request.ShowClosedTickets);
      return View (model);
    }

    TicketListModel GetModel(IList<Ticket> tickets = null,
                             bool showingClosedTickets = false)
    {
      var model = ModelFactory.GetModel<TicketListModel>();

      model.ShowingClosedTickets = showingClosedTickets;
      if(tickets != null)
        model.Tickets = tickets.Select(x => mapper.Map<TicketSummaryDto>(x)).ToList();

      return model;
    }

    TicketListRequest GetRequest(AdHocTicketListSpecification spec)
    {
      if(ReferenceEquals(spec, null))
        return TicketListRequest.CreateDefault();

      return new TicketListRequest
      {
        ShowClosedTickets = spec.ShowClosedTickets,
        ShowOpenTickets = !spec.ShowClosedTickets,
      };
    }

    public TicketsController(ITicketLister lister,
                             IMapper mapper,
                             Services.SharedModel.StandardPageModelFactory modelFactory)
      : base(modelFactory)
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
