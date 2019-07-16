using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CSF.Entities;

namespace Agiil.Domain.Tickets.RelationshipValidation
{
  public class TraversibleRelationshipProvider : IGetsTraversibleRelationships
  {
    readonly IMapper mapper;

    public IEnumerable<TraversibleRelationship> GetTraversibleRelationships(IEnumerable<TheoreticalRelationship> relationships,
                                                                            IEnumerable<HierarchicalTicketRelationship> hierarchicalRelationships)
    {
      var removedRelationships = relationships
        .Where(x => x.Type == TheoreticalRelationshipType.Removed)
        .ToList();

      var removedRelationshipIds = removedRelationships.Select(x => x.TicketRelationship).ToList();

      var traversibleTheoreticalRelationships = relationships
        .Except(removedRelationships)
        .Select(mapper.Map<TraversibleRelationship>)
        .Where(x => !ReferenceEquals(x, null));

      var traversibleHierarchicalRelationships = hierarchicalRelationships
        .Where(x => !removedRelationshipIds.Contains(x.TicketRelationship.GetIdentity()))
        .Select(mapper.Map<TraversibleRelationship>)
        .Where(x => !ReferenceEquals(x, null));

      return traversibleTheoreticalRelationships
        .Union(traversibleHierarchicalRelationships)
        .ToList();
    }

    public TraversibleRelationshipProvider(IMapper mapper)
    {
      this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
  }
}
