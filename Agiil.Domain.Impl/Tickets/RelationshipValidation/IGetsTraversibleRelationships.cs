using System;
using System.Collections.Generic;

namespace Agiil.Domain.Tickets.RelationshipValidation
{
  public interface IGetsTraversibleRelationships
  {
    IEnumerable<TraversibleRelationship> GetTraversibleRelationships(IEnumerable<TheoreticalRelationship> relationships,
                                                                     IEnumerable<HierarchicalTicketRelationship> hierarchicalRelationships);
  }
}
