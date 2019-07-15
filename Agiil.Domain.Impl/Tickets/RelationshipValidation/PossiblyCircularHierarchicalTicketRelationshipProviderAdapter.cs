using System;
using System.Collections.Generic;
using System.Linq;

namespace Agiil.Domain.Tickets.RelationshipValidation
{
  public class PossiblyCircularHierarchicalTicketRelationshipProviderAdapter : IGetsHierarchicalTicketRelationshipsWhichCouldCreateACircularRelationship
  {
    readonly IGetsHierarchicalTicketRelationships hierarchicalRelationshipProvider;

    public IEnumerable<HierarchicalTicketRelationship> GetRelevantHierarchicalRelationships(IEnumerable<TheoreticalRelationship> relationships)
    {
      var directionalRelationships = GetDirectionalRelationshipsWhichDisallowCircles(relationships);

      var primaryTicketIds = directionalRelationships
        .Select(x => x.PrimaryTicket)
        .Where(x => !ReferenceEquals(x, null));

      var secondaryTicketIds = directionalRelationships
        .Select(x => x.SecondaryTicket)
        .Where(x => !ReferenceEquals(x, null));

      var relevantTicketIds = primaryTicketIds
        .Union(secondaryTicketIds)
        .Distinct()
        .ToArray();

      return hierarchicalRelationshipProvider.GetRelationships(relevantTicketIds);
    }

    IEnumerable<TheoreticalRelationship> GetDirectionalRelationshipsWhichDisallowCircles(IEnumerable<TheoreticalRelationship> relationships)
    {
      return relationships
        .Where(x => x?.Relationship?.Type == RelationshipType.Directional
                    && x.Relationship?.Behaviour?.ProhibitCircularRelationship == true)
        .ToList();
    }

    public PossiblyCircularHierarchicalTicketRelationshipProviderAdapter(IGetsHierarchicalTicketRelationships hierarchicalRelationshipProvider)
    {
      this.hierarchicalRelationshipProvider = hierarchicalRelationshipProvider ?? throw new ArgumentNullException(nameof(hierarchicalRelationshipProvider));
    }
  }
}
