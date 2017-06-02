using System;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using AutoMapper;
using CSF.Data.Entities;

namespace Agiil.ObjectMaps.Tickets
{
  public class EditTicketRequestToTicketProfile : Profile
  {
    public EditTicketRequestToTicketProfile(GetEntityByIdentityResolver<Sprint> resolver)
    {
      if(resolver == null)
        throw new ArgumentNullException(nameof(resolver));

      CreateMap<EditTicketRequest,Ticket>()
        .ForMember(x => x.Sprint, opts => opts.ResolveUsing(resolver, x => x.SprintIdentity));
    }
  }
}
