using System;
using System.Linq;

namespace Agiil.Domain.Tickets.Creation
{
  public class RelationshipPopulatingTicketFactoryDecorator : ICreatesTicket
  {
    readonly ICreatesTicket wrappedInstance;
    readonly IConvertsAddRelationshipRequestsToTicketRelationships relationshipFactory;

    public Ticket CreateTicket(CreateTicketRequest request)
    {
      var ticket = wrappedInstance.CreateTicket(request);

      var relationships = relationshipFactory.Convert(request.RelationshipsToAdd);
      ticket.PrimaryRelationships.UnionWith(relationships.Where(x => x.PrimaryTicket == null));
      ticket.SecondaryRelationships.UnionWith(relationships.Where(x => x.SecondaryTicket == null));

      return ticket;
    }

    public RelationshipPopulatingTicketFactoryDecorator(ICreatesTicket wrappedInstance,
                                                        IConvertsAddRelationshipRequestsToTicketRelationships relationshipFactory)
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
