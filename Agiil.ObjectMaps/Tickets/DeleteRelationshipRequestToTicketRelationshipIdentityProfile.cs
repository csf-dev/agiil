using System;
using Agiil.Domain.Tickets;
using AutoMapper;
using CSF.Entities;

namespace Agiil.ObjectMaps.Tickets
{
  public class DeleteRelationshipRequestToTicketRelationshipIdentityProfile : Profile
  {
    public DeleteRelationshipRequestToTicketRelationshipIdentityProfile()
    {
      CreateMap<DeleteRelationshipRequest,IIdentity<TicketRelationship>>()
        .ConstructUsing(req => req?.TicketRelationshipId);
    }
  }
}
