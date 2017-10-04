using System;
using Agiil.Domain.Tickets;
using Agiil.ObjectMaps.Resolvers;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.ObjectMaps.Tickets
{
  public class TicketTypeToTicketTypeDtoProfile : Profile
  {
    public TicketTypeToTicketTypeDtoProfile()
    {
      CreateMap<TicketType,TicketTypeDto>()
        .ForMember(x => x.Id, opts => opts.ResolveUsing<IdentityValueResolver>());
    }
  }
}
