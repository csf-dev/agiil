using System;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;
using CSF.ORM;
using System.Linq;

namespace Agiil.Web.Services.Tickets
{
  public class TicketDetailDtoProvider : IGetsTicketDetailDtoByReference
  {
    readonly IGetsTicketByReference ticketProvider;
    readonly IMapper mapper;
    readonly IEntityData data;

    public TicketDetailDto GetTicketDetailDto(TicketReference reference)
    {
      var ticket = GetTicket(reference);
      if(ticket == null) return null;

      var eagerFetchedTicket = data
        .Query<Ticket>()
        .Where(x => x == ticket)
        .FetchChildren(x => x.Comments)
        .FetchChildren(x => x.PrimaryRelationships)
        .FetchChildren(x => x.SecondaryRelationships)
        .FetchChildren(x => x.Labels)
        .FetchChild(x => x.Project)
        .FetchChild(x => x.User)
        .FetchChild(x => x.Type)
        .AsEnumerable()
        .FirstOrDefault();

      return mapper.Map<TicketDetailDto>(eagerFetchedTicket);
    }

    Ticket GetTicket(TicketReference reference)
    {
      if(reference == null) return null;
      return ticketProvider.GetTicketByReference(reference);
    }

    public TicketDetailDtoProvider(IGetsTicketByReference ticketProvider, IMapper mapper, IEntityData data)
    {
      if(data == null)
        throw new ArgumentNullException(nameof(data));
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(ticketProvider == null)
        throw new ArgumentNullException(nameof(ticketProvider));
      this.ticketProvider = ticketProvider;
      this.mapper = mapper;
      this.data = data;
    }
  }
}
