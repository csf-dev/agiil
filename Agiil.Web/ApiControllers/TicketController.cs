using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Agiil.Domain.Tickets;
using Agiil.Web.Models;
using Agiil.Web.Services.Tickets;
using CSF.Entities;

namespace Agiil.Web.ApiControllers
{
  public class TicketController : ApiController
  {
    readonly ITicketCreator ticketCreator;
    readonly ITicketDetailService ticketDetailService;
    readonly TicketDetailMapper mapper;

    public NewTicketResponse Put(NewTicketSpecification ticket)
    {
      if(ticket == null)
      {
        throw new ArgumentNullException(nameof(ticket));
      }

      var request = new CreateTicketRequest
      {
        Title = ticket.Title,
        Description = ticket.Description,
      };

      var response = ticketCreator.Create(request);

      return new NewTicketResponse
      {
        TitleIsInvalid = response.TitleIsInvalid,
        DescriptionIsInvalid = response.DescriptionIsInvalid,
        TicketIdentity = response.Ticket?.GetIdentity()?.Value,
      };
    }

    public TicketDetailDto Get(IIdentity<Ticket> id)
    {
      var ticket = ticketDetailService.GetTicket(id);

      if(ReferenceEquals(ticket, null))
        throw new HttpResponseException(HttpStatusCode.NotFound);

      return mapper.Map(ticket);
    }

    public TicketController(ITicketCreator ticketCreator,
                            ITicketDetailService ticketDetailService,
                            TicketDetailMapper mapper)
    {
      if(ticketCreator == null)
        throw new ArgumentNullException(nameof(ticketCreator));
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(ticketDetailService == null)
        throw new ArgumentNullException(nameof(ticketDetailService));
      
      this.ticketDetailService = ticketDetailService;
      this.mapper = mapper;
      this.ticketCreator = ticketCreator;
    }
  }
}
