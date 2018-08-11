using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public interface ICreatesTicketRelationship
  {
    TicketRelationship CreateTicketRelationship(IIdentity<Relationship> relationshipId,
                                                TicketReference relatedTicketReference,
                                                RelationshipParticipant participationType);
  }
}
