using System;
using System.Collections.Generic;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public interface IChangesTicketRelationships
  {
    IIdentity<Ticket> EditedTicket { get; }

    IEnumerable<AddRelationshipRequest> RelationshipsToAdd { get; }

    IEnumerable<DeleteRelationshipRequest> RelationshipsToRemove { get; }
  }
}
