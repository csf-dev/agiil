using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.Web.ApiControllers
{
  public class TicketsController : ApiController
  {
    readonly IGetsListOfTickets lister;
    readonly Lazy<IMapper> mapper;

    public IList<TicketSummaryDto> Get(AdHocTicketListSpecification spec)
    {
      var request = mapper.Value.Map<TicketListRequest>(spec);
      var tickets = lister.GetTickets(request);
      return tickets.Select(x => mapper.Value.Map<TicketSummaryDto>(x)).ToList();
    }

    public TicketsController(IGetsListOfTickets lister,
                             Lazy<IMapper> mapper)
    {
      if(lister == null)
        throw new ArgumentNullException(nameof(lister));
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      
      this.lister = lister;
      this.mapper = mapper;
    }
  }
}
