using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class DeleteRelationshipRequest
  {
    public IIdentity<TicketRelationship> TicketRelationshipId { get; set; }
  }
}
