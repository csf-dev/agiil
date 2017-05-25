using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using Agiil.Web.Services.Tickets;

namespace Agiil.Web.Controllers
{
  public class TicketsController : ControllerBase
  {
    readonly ITicketLister lister;
    readonly TicketSummaryMapper mapper;

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
        model.Tickets = mapper.Map(tickets);

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
                             TicketSummaryMapper mapper,
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
