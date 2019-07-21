using System;
using System.Collections.Generic;

namespace Agiil.Domain.Tickets.RelationshipValidation
{
  /// <summary>
  /// Analyses a collection of <see cref="TheoreticalRelationship"/> and returns a collection of
  /// <see cref="HierarchicalTicketRelationship"/> which could feasibly be part of a circular relationship.
  /// This doesn't mean that they are in a circular relationship, only that they are candidates for testing.
  /// </summary>
  public interface IGetsHierarchicalTicketRelationshipsWhichCouldCreateACircularRelationship
  {
    IEnumerable<HierarchicalTicketRelationship> GetRelevantHierarchicalRelationships(IEnumerable<TheoreticalRelationship> relationships);
  }
}
