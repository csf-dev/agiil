using System;
using Agiil.Domain.Tickets;
using AutoMapper;
using CSF.Entities;

namespace Agiil.ObjectMaps.Tickets
{
    public class TicketRelationshipIdentityToDeleteRelationshipRequestProfile : Profile
    {
        public TicketRelationshipIdentityToDeleteRelationshipRequestProfile()
        {
            CreateMap<IIdentity<TicketRelationship>, DeleteRelationshipRequest>()
              .ConstructUsing(identity => {
                  if(identity == null) return null;
                  return new DeleteRelationshipRequest { TicketRelationshipId = identity, };
              })
              .ForMember(x => x.TicketRelationshipId, o => o.Ignore())
              ;
        }
    }
}
