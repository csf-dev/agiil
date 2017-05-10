using System;
using System.Web.Http;
using Agiil.Domain.Tickets;
using Agiil.Web.Models;
using Agiil.Web.Services.Tickets;

namespace Agiil.Web.ApiControllers
{
  public class TicketsController : ApiController
  {
    readonly ITicketLister lister;
    readonly TicketSummaryMapper mapper;

    public TicketListModel Get()
    {
      var tickets = lister.GetTickets();
      return new TicketListModel
      {
        Tickets = mapper.Map(tickets)
      };
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
