using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.Web.ApiControllers
{
  public class TicketsController : ApiControllerBase
  {
    readonly ITicketLister lister;

    public IList<TicketSummaryDto> Get(AdHocTicketListSpecification spec)
    {
      var request = GetRequest(spec);
      var tickets = lister.GetTickets(request);
      return tickets.Select(x => Mapper.Map<TicketSummaryDto>(x)).ToList();
    }

    TicketListRequest GetRequest(AdHocTicketListSpecification spec)
    {
      if(ReferenceEquals(spec, null))
        return TicketListRequest.CreateDefault();

      // TODO: #AG30 - Switch this over to use an IMapper (auto-mapper)
      return new TicketListRequest
      {
        ShowClosedTickets = spec.ShowClosedTickets,
        ShowOpenTickets = !spec.ShowClosedTickets,
      };
    }

    public TicketsController(ITicketLister lister,
                             ApiControllerBaseDependencies deps) : base(deps)
    {
      if(lister == null)
        throw new ArgumentNullException(nameof(lister));
      
      this.lister = lister;
    }
  }
}
