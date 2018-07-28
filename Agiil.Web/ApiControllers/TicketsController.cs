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
    readonly IGetsListOfTicketsFromAgiilQuery lister;
    readonly Lazy<IMapper> mapper;

    public IList<TicketSummaryDto> Get([FromUri] string q)
    {
      if(String.IsNullOrEmpty(q))
        q = "ticket is open";

      var tickets = lister.GetTickets(q);
      return tickets.Select(x => mapper.Value.Map<TicketSummaryDto>(x)).ToList();
    }

    public TicketsController(IGetsListOfTicketsFromAgiilQuery lister,
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
