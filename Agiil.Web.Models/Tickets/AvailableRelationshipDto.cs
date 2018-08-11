using System;
using Agiil.Domain.Tickets;
using CSF.Entities;

namespace Agiil.Web.Models.Tickets
{
  public class AvailableRelationshipDto
  {
    public IIdentity<Relationship> RelationshipIdentity { get; set; }

    public RelationshipParticipant Participant { get; set; }

    public string Summary { get; set; }
  }
}
