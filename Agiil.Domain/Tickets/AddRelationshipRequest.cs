using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class AddRelationshipRequest
  {
    public IIdentity<Relationship> RelationshipId { get; set; }

    public IIdentity<Ticket> RelatedTicketId { get; set; }

    public RelationshipParticipant ParticipationType { get; set; }
  }
}
