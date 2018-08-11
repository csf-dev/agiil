using System;
using CSF.Entities;
using CSF;

namespace Agiil.Domain.Tickets
{
  public class TicketRelationship : Entity<long>
  {
    public virtual Relationship Relationship { get; set; }

    public virtual Ticket PrimaryTicket { get; set; }

    public virtual Ticket SecondaryTicket { get; set; }

    public virtual Ticket GetTicket(RelationshipParticipant participant)
    {
      participant.RequireDefinedValue(nameof(participant));
      if(participant == RelationshipParticipant.Primary) return PrimaryTicket;
      if(participant == RelationshipParticipant.Secondary) return SecondaryTicket;
      return null;
    }
  }
}

