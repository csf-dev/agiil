using System;
using Agiil.Domain.Tickets;
using Agiil.ObjectMaps.Resolvers;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.ObjectMaps.Tickets
{
  public class TicketToTicketSummaryDtoProfile : Profile
  {
    public TicketToTicketSummaryDtoProfile(IGetsTicketUris uriProvider)
    {
      CreateMap<Ticket,TicketSummaryDto>()
        .ForCtorParam("uriProvider", x => x.ResolveUsing(t => uriProvider))
        .ForMember(x => x.Id, o => o.ResolveUsing<IdentityValueResolver>())
        .ForMember(x => x.Creator, o => o.ResolveUsing(t => t.User.Username))
        .ForMember(x => x.Created, o => o.ResolveUsing(t => t.CreationTimestamp))
        .ForMember(x => x.TicketReference, o => o.ResolveUsing(t => t.GetTicketReference()))
        .ForMember(x => x.TypeName, o => o.ResolveUsing(t => t.Type?.Name))
        ;
    }
  }
}
