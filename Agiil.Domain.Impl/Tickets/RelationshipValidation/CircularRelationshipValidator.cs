using System;
using System.Collections.Generic;
using System.Linq;
using CSF.Entities;

namespace Agiil.Domain.Tickets.RelationshipValidation
{
  public class CircularRelationshipValidator : IValidatesTheoreticalTicketRelationships
  {
    readonly IGetsHierarchicalTicketRelationshipsWhichCouldCreateACircularRelationship hierarchicalRelationshipProvider;
    readonly IDetectsCircularRelationship circularRelationshipDetector;
    readonly IGetsTraversibleRelationships traversibleRelationshipProvider;

    public bool AreRelationshipsValid(IIdentity<Ticket> editedTicket, IEnumerable<TheoreticalRelationship> relationships)
    {
      if(ReferenceEquals(relationships, null)) return true;

      var hierarchicalRelationships = hierarchicalRelationshipProvider.GetRelevantHierarchicalRelationships(relationships);
      var traversibleRelationships = traversibleRelationshipProvider.GetTraversibleRelationships(relationships, hierarchicalRelationships);

      if(traversibleRelationships == null)
        return true;

      var relationshipTypes = traversibleRelationships
        .Select(x => x.Type)
        .Distinct()
        .ToList();

      foreach(var type in relationshipTypes)
      {
        if(circularRelationshipDetector.IsRelationshipCircular(type, traversibleRelationships))
          return false;
      }

      return true;
    }

    public CircularRelationshipValidator(IGetsHierarchicalTicketRelationshipsWhichCouldCreateACircularRelationship hierarchicalRelationshipProvider,
                                         IDetectsCircularRelationship circularRelationshipDetector,
                                         IGetsTraversibleRelationships traversibleRelationshipProvider)
    {
      this.hierarchicalRelationshipProvider = hierarchicalRelationshipProvider ?? throw new ArgumentNullException(nameof(hierarchicalRelationshipProvider));
      this.circularRelationshipDetector = circularRelationshipDetector ?? throw new ArgumentNullException(nameof(circularRelationshipDetector));
      this.traversibleRelationshipProvider = traversibleRelationshipProvider ?? throw new ArgumentNullException(nameof(traversibleRelationshipProvider));
    }
  }
}
