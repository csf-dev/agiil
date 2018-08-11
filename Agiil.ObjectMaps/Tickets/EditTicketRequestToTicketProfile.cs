using System;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using Agiil.ObjectMaps.Resolvers;
using AutoMapper;

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

      /* NOTE: This type does not completely map the edit request to the ticket, it may leave many
       * parts of the request unhandled.  This mapping profile is intended to be used as part of a
       * chain of operations coordinated by implementations of IEditsTicket.
       */

      CreateMap<EditTicketRequest,Ticket>()
        .ForMember(x => x.Title, opts => opts.ResolveUsing(s => s.Title))
        .ForMember(x => x.Description, opts => opts.ResolveUsing(s => s.Description))
        .ForMember(x => x.Type, opts => opts.ResolveUsing(typeResolver, x => x.TicketTypeIdentity))
        .ForMember(x => x.Sprint, opts => opts.ResolveUsing(sprintResolver, x => x.SprintIdentity))
        .ForAllOtherMembers(opts => opts.Ignore())
        ;
    }
  }
}
