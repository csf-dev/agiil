using System;
using System.Net;
using System.Web.Http;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;
using CSF.Entities;

namespace Agiil.Web.ApiControllers
{
  public class TicketController : ApiControllerBase
  {
    readonly Lazy<ITicketCreator> ticketCreator;
    readonly Lazy<ITicketEditor> ticketEditor;
    readonly Lazy<ITicketDetailService> ticketDetailService;

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

    public Models.Tickets.EditTicketResponse Post(EditTicketSpecification ticket)
    {
      if(ticket == null)
        throw new ArgumentNullException(nameof(ticket));

      var request = Mapper.Map<EditTicketRequest>(ticket);
      var response = ticketEditor.Value.Edit(request);

      if(response.IdentityIsInvalid)
        throw new HttpResponseException(HttpStatusCode.NotFound);

      return Mapper.Map<Models.Tickets.EditTicketResponse>(response);
    }

    public TicketDetailDto Get(IIdentity<Ticket> id)
    {
      var ticket = ticketDetailService.Value.GetTicket(id);

      if(ReferenceEquals(ticket, null))
        throw new HttpResponseException(HttpStatusCode.NotFound);

      return Mapper.Map<TicketDetailDto>(ticket);
    }

    public TicketController(Lazy<ITicketCreator> ticketCreator,
                            Lazy<ITicketDetailService> ticketDetailService,
                            Lazy<ITicketEditor> ticketEditor,
                            ApiControllerBaseDependencies deps) : base(deps)
    {
      if(ticketCreator == null)
        throw new ArgumentNullException(nameof(ticketCreator));
      if(ticketDetailService == null)
        throw new ArgumentNullException(nameof(ticketDetailService));
      
      this.ticketDetailService = ticketDetailService;
      this.ticketCreator = ticketCreator;
      this.ticketEditor = ticketEditor;
    }
  }
}
