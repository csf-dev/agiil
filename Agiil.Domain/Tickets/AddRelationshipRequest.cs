using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class AddRelationshipRequest
  {
    public IIdentity<Relationship> RelationshipId { get; set; }

    public TicketReference RelatedTicketReference { get; set; }

    public RelationshipParticipant ParticipationType { get; set; }
  }
}
