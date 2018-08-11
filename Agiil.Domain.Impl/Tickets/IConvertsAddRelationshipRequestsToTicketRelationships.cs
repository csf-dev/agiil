using System;
using System.Collections.Generic;

namespace Agiil.Domain.Tickets
{
  public interface IConvertsAddRelationshipRequestsToTicketRelationships
  {
    IReadOnlyCollection<TicketRelationship> Convert(IEnumerable<AddRelationshipRequest> requests);
  }
}
