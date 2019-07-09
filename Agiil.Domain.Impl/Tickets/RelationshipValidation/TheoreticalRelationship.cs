using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets.RelationshipValidation
{
  public class TheoreticalRelationship : IEquatable<TheoreticalRelationship>
  {
    public IIdentity<TicketRelationship> TicketRelationship { get; set; }
    public IIdentity<Ticket> PrimaryTicket { get; set; }
    public IIdentity<Ticket> SecondaryTicket { get; set; }
    public Relationship Relationship { get; set; }

    public override bool Equals(object obj)
    {
      if(ReferenceEquals(obj, this)) return true;
      if(ReferenceEquals(obj, null)) return false;
      return Equals(obj as TheoreticalRelationship);
    }

    public bool Equals(TheoreticalRelationship other)
    {
      if(ReferenceEquals(other, this)) return true;
      if(ReferenceEquals(other, null)) return false;

      return (PrimaryTicket?.Equals(other.PrimaryTicket) == true
              && SecondaryTicket?.Equals(other.SecondaryTicket) == true
              && (
                (TicketRelationship == null && other.TicketRelationship == null)
                || (TicketRelationship?.Equals(other.TicketRelationship) == true)
              )
              && Relationship?.Equals(other.Relationship) == true);
    }

    public override int GetHashCode()
    {
      var ticketRelationshipHash = (TicketRelationship?.GetHashCode()).GetValueOrDefault(19);
      var primaryHash = (PrimaryTicket?.GetHashCode()).GetValueOrDefault(23);
      var secondaryHash = (SecondaryTicket?.GetHashCode()).GetValueOrDefault(29);
      var relationshipHash = (Relationship?.GetHashCode()).GetValueOrDefault(37);

      return ticketRelationshipHash ^ primaryHash ^ secondaryHash ^ relationshipHash;
    }

    public override string ToString()
    {
      return $"[{nameof(TheoreticalRelationship)}: Primary: {PrimaryTicket}, Secondary: {SecondaryTicket}, Relationship: {Relationship?.GetIdentity()}, TicketRelationship: {TicketRelationship}]";
    }
  }
}
