using System;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using Agiil.ObjectMaps.Resolvers;
using AutoMapper;
using CSF.Data.Entities;

namespace Agiil.ObjectMaps.Tickets
{
  public class EditTicketRequestToTicketProfile : Profile
  {
    public EditTicketRequestToTicketProfile(GetEntityByIdentityResolver<Sprint> sprintResolver,
                                            GetEntityByIdentityResolver<TicketType> typeResolver)
    {
      if(typeResolver == null)
        throw new ArgumentNullException(nameof(typeResolver));
      if(sprintResolver == null)
        throw new ArgumentNullException(nameof(sprintResolver));

      CreateMap<EditTicketRequest,Ticket>()
        .ForMember(x => x.Sprint, opts => opts.ResolveUsing(sprintResolver, x => x.SprintIdentity))
        .ForMember(x => x.Type, opts => opts.ResolveUsing(typeResolver, x => x.TicketTypeIdentity))
        ;
    }
  }
}
