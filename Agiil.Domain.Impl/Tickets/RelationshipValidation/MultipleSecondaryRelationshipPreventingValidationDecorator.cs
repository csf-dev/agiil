using System;
using System.Collections.Generic;
using System.Linq;
using CSF.Entities;
using log4net;

namespace Agiil.Domain.Tickets.RelationshipValidation
{
  public class MultipleSecondaryRelationshipPreventingValidationDecorator : IValidatesTheoreticalTicketRelationships
  {
    readonly IValidatesTheoreticalTicketRelationships wrapped;
    private readonly ILog logger;

    public bool AreRelationshipsValid(IIdentity<Ticket> editedTicket, IEnumerable<TheoreticalRelationship> relationships)
    {
      if(ReferenceEquals(relationships, null)) return true;

      logger.Debug($"Beginning validation, considering {relationships.Count()} relationship(s)");

      if(AreThereAnyProhibitedRelationships(editedTicket, relationships))
        return false;
      return wrapped.AreRelationshipsValid(editedTicket, relationships);
    }

    bool AreThereAnyProhibitedRelationships(IIdentity<Ticket> editedTicket,
                                            IEnumerable<TheoreticalRelationship> relationships)
    {
      var relationshipGroups = (from relationship in relationships
                                where
                                  relationship.Relationship.Type == RelationshipType.Directional
                                  && relationship.Relationship.Behaviour.ProhibitMultipleSecondaryRelationships
                                  && (Equals(relationship.SecondaryTicket, editedTicket)
                                      || (ReferenceEquals(relationship.SecondaryTicket, null)
                                          && ReferenceEquals(editedTicket, null)))
                                  && relationship.Type != TheoreticalRelationshipType.Removed
                                group relationship by relationship.Relationship into groupedRelationships
                                select new { Count = groupedRelationships.Count(), Key = groupedRelationships.Key })
        .ToList();

      var result = relationshipGroups.Any(x => x.Count > 1);

      if(result && logger.IsDebugEnabled)
      {
        var failingRelationships = String.Join(", ", relationshipGroups.Select(x => x.Key.PrimarySummary));
        logger.Debug($"Validation failed; duplicate secondary relationships detected: \"{failingRelationships}\"");
      }
      else
      {
        logger.Debug("Validation passed");
      }

      return result;
    }

    public MultipleSecondaryRelationshipPreventingValidationDecorator(IValidatesTheoreticalTicketRelationships wrapped,
                                                                      ILog logger)
    {
      this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
      this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

      logger.Debug("Constructor completed");
    }
  }
}
