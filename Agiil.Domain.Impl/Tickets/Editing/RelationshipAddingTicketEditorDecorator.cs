using System;
using System.Linq;

namespace Agiil.Domain.Tickets.Editing
{
  public class RelationshipAddingTicketEditorDecorator : IEditsTicket
  {
    readonly IEditsTicket wrappedInstance;
    readonly IConvertsAddRelationshipRequestsToTicketRelationships relationshipFactory;

    public void Edit(Ticket ticket, EditTicketRequest request)
    {
      wrappedInstance.Edit(ticket, request);

      var relationships = relationshipFactory.Convert(request.RelationshipsToAdd);
      ticket.PrimaryRelationships.UnionWith(relationships.Where(x => x.PrimaryTicket == null));
      ticket.SecondaryRelationships.UnionWith(relationships.Where(x => x.SecondaryTicket == null));
    }

    public RelationshipAddingTicketEditorDecorator(IEditsTicket wrappedInstance,
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
