using System;
using System.Net;
using System.Web.Http;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;
using CSF.Entities;
using log4net;

namespace Agiil.Web.ApiControllers
{
    public class TicketController : ApiController
    {
        readonly Lazy<IHandlesCreateTicketRequest> ticketCreator;
        readonly Lazy<IHandlesEditTicketRequest> ticketEditor;
        readonly Lazy<ITicketDetailService> ticketDetailService;
        readonly Lazy<IMapper> mapper;
        readonly ILog logger;

        public NewTicketResponse Put(NewTicketSpecification ticket)
        {
            if(ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket));
            }

            var request = mapper.Value.Map<CreateTicketRequest>(ticket);
            var response = ticketCreator.Value.Create(request);
            return mapper.Value.Map<NewTicketResponse>(response);
        }

        public Models.Tickets.EditTicketResponse Post(EditTicketSpecification ticket)
        {
            if(ticket == null) throw new ArgumentNullException(nameof(ticket));

            logger.Debug($"{nameof(EditTicketSpecification)} ticket identity is {ticket.Identity}");

            var request = mapper.Value.Map<EditTicketRequest>(ticket);
            var response = ticketEditor.Value.Edit(request);

            if(response.IdentityIsInvalid)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return mapper.Value.Map<Models.Tickets.EditTicketResponse>(response);
        }

        public TicketDetailDto Get(IIdentity<Ticket> id)
        {
            var ticket = ticketDetailService.Value.GetTicket(id);

            if(ReferenceEquals(ticket, null))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return mapper.Value.Map<TicketDetailDto>(ticket);
        }

        public TicketController(Lazy<IHandlesCreateTicketRequest> ticketCreator,
                                Lazy<ITicketDetailService> ticketDetailService,
                                Lazy<IHandlesEditTicketRequest> ticketEditor,
                                Lazy<IMapper> mapper,
                                ILog logger)
        {
            if(ticketCreator == null)
                throw new ArgumentNullException(nameof(ticketCreator));
            if(ticketDetailService == null)
                throw new ArgumentNullException(nameof(ticketDetailService));
            if(mapper == null)
                throw new ArgumentNullException(nameof(mapper));

            this.ticketDetailService = ticketDetailService;
            this.ticketCreator = ticketCreator;
            this.ticketEditor = ticketEditor;
            this.mapper = mapper;
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
