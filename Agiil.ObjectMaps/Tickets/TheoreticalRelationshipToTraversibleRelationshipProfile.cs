using System;
using Agiil.Domain.Tickets.RelationshipValidation;
using AutoMapper;
using CSF.Entities;

namespace Agiil.ObjectMaps.Tickets
{
  public class TheoreticalRelationshipToTraversibleRelationshipProfile : Profile
  {
    public TheoreticalRelationshipToTraversibleRelationshipProfile()
    {
      CreateMap<TheoreticalRelationship,TraversibleRelationship>()
        .ConstructUsing(GetTraversibleRelationship)
        .ForAllMembers(opts => opts.Ignore());
    }

    TraversibleRelationship GetTraversibleRelationship(TheoreticalRelationship relationship)
    {
      if(ReferenceEquals(relationship, null)) return null;
      return new TraversibleRelationship(relationship.TicketRelationship,
                                         relationship.PrimaryTicket,
                                         relationship.SecondaryTicket,
                                         relationship.Relationship?.GetIdentity());
    }
  }
}
