using System;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;
using CSF.Data.Entities;
using System.Linq;
using CSF.Data.NHibernate;

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
        .FetchMany(x => x.Comments)
        .FetchMany(x => x.PrimaryRelationships)
        .FetchMany(x => x.SecondaryRelationships)
        .FetchMany(x => x.Labels)
        .Fetch(x => x.Project)
        .Fetch(x => x.User)
        .Fetch(x => x.Type)
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
