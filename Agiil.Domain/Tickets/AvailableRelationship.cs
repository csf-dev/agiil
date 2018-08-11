using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class AvailableRelationship
  {
    public IIdentity<Relationship> RelationshipIdentity { get; set; }

    public RelationshipParticipant Participant { get; set; }

    public string Summary { get; set; }
  }
}
