using System;
using System.Net;
using System.Web.Http;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;
using CSF.Entities;

namespace Agiil.Web.ApiControllers
{
  public class TicketController : ApiController
  {
    readonly Lazy<ITicketCreator> ticketCreator;
    readonly Lazy<ITicketEditor> ticketEditor;
    readonly Lazy<ITicketDetailService> ticketDetailService;
    readonly IMapper mapper;

    public NewTicketResponse Put(NewTicketSpecification ticket)
    {
      if(ticket == null)
      {
        throw new ArgumentNullException(nameof(ticket));
      }

      // TODO: #AG30 - Switch this over to use an IMapper (auto-mapper)
      var request = new CreateTicketRequest
      {
        Title = ticket.Title,
        Description = ticket.Description,
      };

      var response = ticketCreator.Value.Create(request);

      // TODO: #AG30 - Switch this over to use an IMapper (auto-mapper)
      return new NewTicketResponse
      {
        TitleIsInvalid = response.TitleIsInvalid,
        DescriptionIsInvalid = response.DescriptionIsInvalid,
        TicketIdentity = response.Ticket?.GetIdentity()?.Value,
      };
    }

    public Models.Tickets.EditTicketTitleAndDescriptionResponse Post(EditTicketTitleAndDescriptionSpecification ticket)
    {
      if(ticket == null)
      {
        throw new ArgumentNullException(nameof(ticket));
      }

      // TODO: #AG30 - Switch this over to use an IMapper (auto-mapper)
      var request = new EditTicketTitleAndDescriptionRequest
      {
        Identity = ticket.Identity,
        Title = ticket.Title,
        Description = ticket.Description,
      };

      var response = ticketEditor.Value.Edit(request);

      if(response.IdentityIsInvalid)
        throw new HttpResponseException(HttpStatusCode.NotFound);

      // TODO: #AG30 - Switch this over to use an IMapper (auto-mapper)
      return new Models.Tickets.EditTicketTitleAndDescriptionResponse
      {
        Success = response.IsSuccess,
        TitleIsInvalid = response.TitleIsInvalid,
        DescriptionIsInvalid = response.DescriptionIsInvalid,
      };
    }

    public TicketDetailDto Get(IIdentity<Ticket> id)
    {
      var ticket = ticketDetailService.Value.GetTicket(id);

      if(ReferenceEquals(ticket, null))
        throw new HttpResponseException(HttpStatusCode.NotFound);

      return mapper.Map<TicketDetailDto>(ticket);
    }

    public TicketController(Lazy<ITicketCreator> ticketCreator,
                            Lazy<ITicketDetailService> ticketDetailService,
                            Lazy<ITicketEditor> ticketEditor,
                            IMapper mapper)
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
      this.ticketEditor = ticketEditor;
    }
  }
}
