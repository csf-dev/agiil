using System;
using Agiil.Domain.Tickets;
using Agiil.ObjectMaps.Resolvers;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.ObjectMaps.Tickets
{
  public class TicketToTicketSummaryDtoProfile : Profile
  {
    public TicketToTicketSummaryDtoProfile(TicketReferenceStringResolver ticketRefResolver)
    {
      CreateMap<Ticket,TicketSummaryDto>()
        .ForMember(x => x.Id, o => o.ResolveUsing<IdentityValueResolver>())
        .ForMember(x => x.Creator, o => o.ResolveUsing(t => t.User.Username))
        .ForMember(x => x.Created, o => o.ResolveUsing(t => t.CreationTimestamp))
        .ForMember(x => x.Reference, o => o.ResolveUsing(ticketRefResolver))
        .ForMember(x => x.TypeName, o => o.ResolveUsing(t => t.Type?.Name))
        ;
    }
  }
}
