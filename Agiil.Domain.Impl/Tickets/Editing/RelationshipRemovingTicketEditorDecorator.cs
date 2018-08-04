using System;
using System.Collections.Generic;
using System.Linq;
using CSF.Entities;

namespace Agiil.Domain.Tickets.Editing
{
  public class RelationshipRemovingTicketEditorDecorator : IEditsTicket
  {
    readonly IEditsTicket wrappedInstance;

    public void Edit(Ticket ticket, EditTicketRequest request)
    {
      wrappedInstance.Edit(ticket, request);

      RemoveRelationships(ticket.PrimaryRelationships,
                          request.RelationshipsToDelete.Select(x => x.TicketRelationshipId));
      
      RemoveRelationships(ticket.SecondaryRelationships,
                          request.RelationshipsToDelete.Select(x => x.TicketRelationshipId));
    }

    void RemoveRelationships(ISet<TicketRelationship> relationships,
                             IEnumerable<IIdentity<TicketRelationship>> toDelete)
    {
      var toRemove = (from relationship in relationships
                      let id = relationship.GetIdentity()
                      where toDelete.Contains(id)
                      select relationship)
        .ToArray();

      relationships.ExceptWith(toRemove);
    }

    public RelationshipRemovingTicketEditorDecorator(IEditsTicket wrappedInstance)
    {
      if(wrappedInstance == null)
        throw new ArgumentNullException(nameof(wrappedInstance));
      this.wrappedInstance = wrappedInstance;
    }
  }
}
