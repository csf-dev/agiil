using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets.RelationshipValidation
{
  public class TraversibleRelationship : IEquatable<TraversibleRelationship>
  {
    public IIdentity<TicketRelationship> Id { get; private set; }
    public IIdentity<Ticket> Start { get; private set; }
    public IIdentity<Ticket> End { get; private set; }
    public IIdentity<Relationship> Type { get; private set; }

    public bool CanTraverseTo(TraversibleRelationship relationship)
    {
      if(ReferenceEquals(relationship, null)) return false;
      return Equals(End, relationship.Start) && Equals(Type, relationship.Type);
    }

    public bool Equals(TraversibleRelationship other)
    {
      if(ReferenceEquals(other, this)) return true;
      if(ReferenceEquals(other, null)) return false;
      return Equals(Id, other.Id);
    }

    public TraversibleRelationship(IIdentity<TicketRelationship> id,
                                   IIdentity<Ticket> start,
                                   IIdentity<Ticket> end,
                                   IIdentity<Relationship> type)
    {
      Id = id;
      Start = start;
      End = end;
      Type = type ?? throw new ArgumentNullException(nameof(type));
    }
  }
}
