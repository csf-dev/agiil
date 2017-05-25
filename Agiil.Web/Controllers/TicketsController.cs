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
        model.Tickets = tickets.Select(x => Mapper.Map<TicketSummaryDto>(x)).ToList();

      return model;
    }

    // TODO: Switch this over to use the Mapper on the base class
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
                             ControllerBaseDependencies baseDeps)
      : base(baseDeps)
    {
      if(lister == null)
        throw new ArgumentNullException(nameof(lister));
      this.lister = lister;
    }
  }
}
