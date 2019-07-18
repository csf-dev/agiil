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
      if(ReferenceEquals(ticketIdentity, null)) return new List<TheoreticalRelationship>();

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

    List<TheoreticalRelationship> GetAddedRelationships(IIdentity<Ticket> editedTicketIdentity, IEnumerable<AddRelationshipRequest> added)
    {
      if(added == null || !added.Any()) return new List<TheoreticalRelationship>();

      return added
        .Where(x => !ReferenceEquals(x.RelationshipId, null))
        .Select(add => new {
          relatedTicket = ticketProvider.GetTicketByReference(add.RelatedTicketReference),
          relatedIsPrimary = add.ParticipationType == RelationshipParticipant.Secondary,
          relationshipType = data.Get(add.RelationshipId)
        })
        .Where(x => x.relatedTicket != null)
        .Select(x => {

          return new TheoreticalRelationship {
            Relationship = x.relationshipType,
            PrimaryTicket = x.relatedIsPrimary? x.relatedTicket.GetIdentity() : editedTicketIdentity,
            SecondaryTicket = x.relatedIsPrimary ? editedTicketIdentity : x.relatedTicket.GetIdentity(),
            Type = TheoreticalRelationshipType.Added,
          };
        })
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
