using System;
using System.Collections.Generic;
using CSF.Entities;

namespace Agiil.Domain.Tickets.RelationshipValidation
{
  public interface IGetsTheoreticalTicketRelationships
  {
    IReadOnlyCollection<TheoreticalRelationship> GetTheoreticalTicketRelationships(IIdentity<Ticket> ticketIdentity = null,
                                                                                   IEnumerable<AddRelationshipRequest> added = null,
                                                                                   IEnumerable<DeleteRelationshipRequest> removed = null);
  }
}
