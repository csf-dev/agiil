using System;
using System.Web.Http;
using Agiil.Domain.Tickets;
using Agiil.Web.Models;
using CSF.Entities;

namespace Agiil.Web.ApiControllers
{
  [Authorize]
  public class TicketController : ApiController
  {
    readonly ITicketCreator ticketCreator;

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

    public TicketDetail Get(long id)
    {
      // TODO: Write this implementation
      throw new NotImplementedException();
    }

    public TicketController(ITicketCreator ticketCreator)
    {
      if(ticketCreator == null)
        throw new ArgumentNullException(nameof(ticketCreator));

      this.ticketCreator = ticketCreator;
    }
  }
}
