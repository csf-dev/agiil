using System;
using CSF;
using CSF.Data.Entities;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class TicketRelationshipFactory : ICreatesTicketRelationship
  {
    readonly IEntityData data;
    readonly ITicketReferenceQuery ticketQuery;

    public TicketRelationship CreateTicketRelationship(IIdentity<Relationship> relationshipId,
                                                       TicketReference relatedTicketReference,
                                                       RelationshipParticipant participationType)
    {
      if(relationshipId == null || relatedTicketReference == null || !participationType.IsDefinedValue())
        return null;

      var relatedTicket = ticketQuery.GetTicketByReference(relatedTicketReference);
      if(relatedTicket == null) return null;

      var relationship = new TicketRelationship {
        Relationship = data.Theorise(relationshipId),
      };

      if(participationType == RelationshipParticipant.Primary)
        relationship.SecondaryTicket = relatedTicket;
      
      if(participationType == RelationshipParticipant.Secondary)
        relationship.PrimaryTicket = relatedTicket;

      return relationship;
    }

    public TicketRelationshipFactory(IEntityData data, ITicketReferenceQuery ticketQuery)
    {
      if(ticketQuery == null)
        throw new ArgumentNullException(nameof(ticketQuery));
      if(data == null)
        throw new ArgumentNullException(nameof(data));
      this.data = data;
      this.ticketQuery = ticketQuery;
    }
  }
}
