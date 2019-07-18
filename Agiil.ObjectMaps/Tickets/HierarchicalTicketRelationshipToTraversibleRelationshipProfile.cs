using System;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.RelationshipValidation;
using AutoMapper;
using CSF.Entities;

namespace Agiil.ObjectMaps.Tickets
{
  public class HierarchicalTicketRelationshipToTraversibleRelationshipProfile : Profile
  {
    public HierarchicalTicketRelationshipToTraversibleRelationshipProfile()
    {
      CreateMap<HierarchicalTicketRelationship, TraversibleRelationship>()
        .ConstructUsing(GetTraversibleRelationship)
        .ForAllMembers(opts => opts.Ignore());
    }

    TraversibleRelationship GetTraversibleRelationship(HierarchicalTicketRelationship relationship)
    {
      if(ReferenceEquals(relationship, null)) return null;
      return new TraversibleRelationship(relationship.TicketRelationship?.GetIdentity(),
                                         relationship.TicketRelationship?.PrimaryTicket?.GetIdentity(),
                                         relationship.TicketRelationship?.SecondaryTicket?.GetIdentity(),
                                         relationship.TicketRelationship?.Relationship?.GetIdentity());
    }
  }
}
