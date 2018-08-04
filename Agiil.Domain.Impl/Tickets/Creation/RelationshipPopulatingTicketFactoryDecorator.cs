using System;
using System.Collections.Generic;
using System.Linq;

namespace Agiil.Domain.Tickets.Creation
{
  public class RelationshipPopulatingTicketFactoryDecorator : ICreatesTicket
  {
    readonly ICreatesTicket wrappedInstance;
    readonly ICreatesTicketRelationship relationshipFactory;

    public Ticket CreateTicket(CreateTicketRequest request)
    {
      var ticket = wrappedInstance.CreateTicket(request);

      var relationships = GetRelationships(request.RelationshipsToAdd);
      ticket.PrimaryRelationships.UnionWith(relationships.Where(x => x.PrimaryTicket == null));
      ticket.SecondaryRelationships.UnionWith(relationships.Where(x => x.SecondaryTicket == null));

      return ticket;
    }

    IReadOnlyList<TicketRelationship> GetRelationships(IEnumerable<AddRelationshipRequest> requests)
    {
      return requests
        .Select(x => relationshipFactory.CreateTicketRelationship(x.RelationshipId,
                                                                  x.RelatedTicketReference,
                                                                  x.ParticipationType))
        .Where(x => x != null)
        .ToArray();
    }

    public RelationshipPopulatingTicketFactoryDecorator(ICreatesTicket wrappedInstance,
                                                        ICreatesTicketRelationship relationshipFactory)
    {
      if(relationshipFactory == null)
        throw new ArgumentNullException(nameof(relationshipFactory));
      if(wrappedInstance == null)
        throw new ArgumentNullException(nameof(wrappedInstance));
      this.wrappedInstance = wrappedInstance;
      this.relationshipFactory = relationshipFactory;
    }
  }
}
