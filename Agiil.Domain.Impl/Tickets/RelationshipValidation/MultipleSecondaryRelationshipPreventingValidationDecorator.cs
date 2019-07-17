using System;
using System.Collections.Generic;
using System.Linq;
using CSF.Entities;

namespace Agiil.Domain.Tickets.RelationshipValidation
{
  public class MultipleSecondaryRelationshipPreventingValidationDecorator : IValidatesTheoreticalTicketRelationships
  {
    readonly IValidatesTheoreticalTicketRelationships wrapped;

    public bool AreRelationshipsValid(IIdentity<Ticket> editedTicket, IEnumerable<TheoreticalRelationship> relationships)
    {
      if(ReferenceEquals(relationships, null)) return true;

      if(AreThereAnyProhibitedRelationships(editedTicket, relationships))
        return false;
      return wrapped.AreRelationshipsValid(editedTicket, relationships);
    }

    bool AreThereAnyProhibitedRelationships(IIdentity<Ticket> editedTicket,
                                            IEnumerable<TheoreticalRelationship> relationships)
    {
      var relationshipGroups = (from relationship in relationships
                                where
                                  (relationship.Relationship is DirectionalRelationship)
                                  && relationship.Relationship.Behaviour.ProhibitMultipleSecondaryRelationships
                                  && Equals(relationship.SecondaryTicket, editedTicket)
                                  && relationship.Type != TheoreticalRelationshipType.Removed
                                group relationship by relationship.Relationship into groupedRelationships
                                select new { Count = groupedRelationships.Count() })
        .ToList();

      return relationshipGroups.Any(x => x.Count > 1);
    }

    public MultipleSecondaryRelationshipPreventingValidationDecorator(IValidatesTheoreticalTicketRelationships wrapped)
    {
      this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
    }
  }
}
