using System;
using System.Linq;
using Agiil.Domain.Tickets;
using Agiil.ObjectMaps.Resolvers;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.ObjectMaps.Tickets
{
  public class TicketToTicketDetailDtoProfile : Profile
  {
    public TicketToTicketDetailDtoProfile()
    {
      CreateMap<Ticket,TicketDetailDto>()
        .ForMember(x => x.Id, o => o.ResolveUsing<IdentityValueResolver>())
        .ForMember(x => x.Creator, o => o.ResolveUsing(t => t.User.Username))
        .ForMember(x => x.Created, o => o.ResolveUsing(t => t.CreationTimestamp))
        .ForMember(x => x.Reference, o => o.ResolveUsing<TicketReferenceStringResolver>())
        .AfterMap((ticket, dto) => {
          dto.Comments = dto.Comments.OrderBy(x => x.Timestamp).ToArray();
        })
        ;
    }
  }
}
