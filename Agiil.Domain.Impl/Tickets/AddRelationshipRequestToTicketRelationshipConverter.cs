using System;
using System.Collections.Generic;
using System.Linq;

namespace Agiil.Domain.Tickets
{
  public class AddRelationshipRequestToTicketRelationshipConverter
    : IConvertsAddRelationshipRequestsToTicketRelationships
  {
    readonly ICreatesTicketRelationship relationshipFactory;

    public IReadOnlyCollection<TicketRelationship> Convert(IEnumerable<AddRelationshipRequest> requests)
    {
      return requests
        .Select(x => relationshipFactory.CreateTicketRelationship(x.RelationshipId,
                                                                  x.RelatedTicketReference,
                                                                  x.ParticipationType))
        .Where(x => x != null)
        .ToArray();
    }

    public AddRelationshipRequestToTicketRelationshipConverter(ICreatesTicketRelationship relationshipFactory)
    {
      if(relationshipFactory == null)
        throw new ArgumentNullException(nameof(relationshipFactory));
      this.relationshipFactory = relationshipFactory;
    }
  }
}
