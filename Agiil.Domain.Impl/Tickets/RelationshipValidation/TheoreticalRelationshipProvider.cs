using System;
using System.Collections.Generic;
using CSF.Data.Entities;
using CSF.Entities;
using System.Linq;
using CSF.Data.NHibernate;

namespace Agiil.Domain.Tickets.RelationshipValidation
{
  public class TheoreticalRelationshipProvider : IGetsTheoreticalTicketRelationships
  {
    readonly IEntityData data;
    readonly IGetsTicketByReference ticketProvider;

    public IReadOnlyCollection<TheoreticalRelationship> GetTheoreticalTicketRelationships(IIdentity<Ticket> ticketIdentity = null,
                                                                                          IEnumerable<AddRelationshipRequest> added = null,
                                                                                          IEnumerable<DeleteRelationshipRequest> removed = null)
    {
      var existingRelationships = GetExistingRelationships(ticketIdentity);
      MarkupRemovedRelationships(existingRelationships, removed);
      var addedRelationships = GetAddedRelationships(ticketIdentity, added);

      return existingRelationships.Union(addedRelationships).ToArray();
    }

    List<TheoreticalRelationship> GetExistingRelationships(IIdentity<Ticket> ticketIdentity)
    {
      if(ticketIdentity == null) return new List<TheoreticalRelationship>();

      var ticket = data.Theorise(ticketIdentity);
      return (from rel in data.Query<TicketRelationship>()
              where
                rel.PrimaryTicket == ticket
                || rel.SecondaryTicket == ticket
              select rel)
        .Fetch(x => x.Relationship)
        .AsEnumerable()
        .Select(MapToTheoreticalRelationship)
        .ToList();
    }

    void MarkupRemovedRelationships(List<TheoreticalRelationship> existing,
                                    IEnumerable<DeleteRelationshipRequest> toDelete)
    {
      if(toDelete == null || !toDelete.Any()) return;

      foreach(var removed in existing.Where(x => toDelete.Any(d => Equals(d.TicketRelationshipId, x.TicketRelationship))))
      {
        removed.Type = TheoreticalRelationshipType.Removed;
      }
    }

    List<TheoreticalRelationship> GetAddedRelationships(IIdentity<Ticket> ticketIdentity, IEnumerable<AddRelationshipRequest> added)
    {
      if(added == null || !added.Any()) return new List<TheoreticalRelationship>();

      var relationshipTypes = GetRelationshipTypes(added);

      return added
        .Select(add => {
          var ticket = ticketProvider.GetTicketByReference(add.RelatedTicketReference);
          var relatedIsPrimary = add.ParticipationType == RelationshipParticipant.Secondary;
          var relationshipType = relationshipTypes.Single(x => x.GetIdentity() == add.RelationshipId);

          return new TheoreticalRelationship {
            Relationship = relationshipType,
            SecondaryTicket = relatedIsPrimary? ticket.GetIdentity() : ticketIdentity,
            PrimaryTicket = relatedIsPrimary ? ticketIdentity : ticket.GetIdentity(),
            Type = TheoreticalRelationshipType.Added,
          };
        })
        .ToList();
    }

    List<Relationship> GetRelationshipTypes(IEnumerable<AddRelationshipRequest> added)
    {
      var distinctTypes = added
        .Select(x => x.RelationshipId)
        .Distinct()
        .Select(x => data.Theorise(x))
        .ToList();

      return (from relationship in data.Query<Relationship>()
              where distinctTypes.Contains(relationship)
              select relationship)
        .Fetch(x => x.Behaviour)
        .ToList();
    }

    TheoreticalRelationship MapToTheoreticalRelationship(TicketRelationship tr)
    {
      return new TheoreticalRelationship {
        PrimaryTicket = tr.PrimaryTicket.GetIdentity(),
        SecondaryTicket = tr.SecondaryTicket.GetIdentity(),
        TicketRelationship = tr.GetIdentity(),
        Relationship = tr.Relationship,
        Type = TheoreticalRelationshipType.Existing,
      };
    }

    public TheoreticalRelationshipProvider(IEntityData data, IGetsTicketByReference ticketProvider)
    {
      this.data = data ?? throw new ArgumentNullException(nameof(data));
      this.ticketProvider = ticketProvider ?? throw new ArgumentNullException(nameof(ticketProvider));
    }
  }
}
