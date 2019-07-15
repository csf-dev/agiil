using System;
using System.Collections.Generic;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  /// <summary>
  /// Gets a collection of <see cref="HierarchicalTicketRelationship"/> which represents every
  /// <see cref="DirectionalRelationship"/> which is reachable from any of the input <paramref name="ticketIdentities" />.
  /// This includes following ancestor/descendent relationships, to create a full hierarchy.
  /// </summary>
  public interface IGetsHierarchicalTicketRelationships
  {
    IEnumerable<HierarchicalTicketRelationship> GetRelationships(params IIdentity<Ticket>[] ticketIdentities);
  }
}
