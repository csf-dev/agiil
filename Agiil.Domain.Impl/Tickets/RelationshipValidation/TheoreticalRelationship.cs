using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets.RelationshipValidation
{
  public sealed class TheoreticalRelationship : IEquatable<TheoreticalRelationship>
  {
    public IIdentity<TicketRelationship> TicketRelationship { get; set; }
    public IIdentity<Ticket> PrimaryTicket { get; set; }
    public IIdentity<Ticket> SecondaryTicket { get; set; }
    public Relationship Relationship { get; set; }
    public TheoreticalRelationshipType Type { get; set; }

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

      return (Equals(PrimaryTicket, other.PrimaryTicket)
              && Equals(SecondaryTicket, other.SecondaryTicket)
              && Equals(TicketRelationship, other.TicketRelationship)
              && Equals(Relationship, other.Relationship)
              && Equals(Type, other.Type));
    }

    public override int GetHashCode()
    {
      var ticketRelationshipHash = (TicketRelationship?.GetHashCode()).GetValueOrDefault(19);
      var primaryHash = (PrimaryTicket?.GetHashCode()).GetValueOrDefault(23);
      var secondaryHash = (SecondaryTicket?.GetHashCode()).GetValueOrDefault(29);
      var relationshipHash = (Relationship?.GetHashCode()).GetValueOrDefault(37);
      var typeHash = Type.GetHashCode();

      return ticketRelationshipHash ^ primaryHash ^ secondaryHash ^ relationshipHash ^ typeHash;
    }

    public override string ToString()
    {
      return $"[{nameof(TheoreticalRelationship)}: Primary: {PrimaryTicket}, Secondary: {SecondaryTicket}, Relationship: {Relationship?.GetIdentity()}, TicketRelationship: {TicketRelationship}, Type: {Type}]";
    }
  }
}
