using System;
using Agiil.Domain.Tickets;
using CSF.Entities;

namespace Agiil.Web.Models.Tickets
{
  public class TicketRelationshipDto
  {
    public IIdentity<TicketRelationship> Id { get; set; }

    public IIdentity<Relationship> RelationshipId { get; set; }

    public RelationshipParticipant Participant { get; set; }
    
    public string Summary { get; set; }

    public TicketSummaryDto RelatedTicket { get; set; }
  }
}
