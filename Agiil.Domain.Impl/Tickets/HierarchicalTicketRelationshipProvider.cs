using System;
using System.Collections.Generic;
using System.Linq;
using CSF.Entities;
using NHibernate;

namespace Agiil.Domain.Tickets
{
  public class HierarchicalTicketRelationshipProvider : IGetsHierarchicalTicketRelationships
  {
    readonly ISession session;

    public IEnumerable<HierarchicalTicketRelationship> GetRelationships(params IIdentity<Ticket>[] ticketIdentities)
    {
      if(ticketIdentities == null)
        throw new ArgumentNullException(nameof(ticketIdentities));
      if(ticketIdentities.Length == 0) return Enumerable.Empty<HierarchicalTicketRelationship>();

      var query = GetSQLQuery(ticketIdentities);
      return query.List<HierarchicalTicketRelationship>();
    }

    ISQLQuery GetSQLQuery(IIdentity<Ticket>[] ticketIdentities)
    {
      var queryString = GetQueryString(ticketIdentities.Length);
      var query = session.CreateSQLQuery(queryString);

      query
        .AddEntity("htr", typeof(HierarchicalTicketRelationship))
        .AddJoin("tr", $"htr.{nameof(HierarchicalTicketRelationship.TicketRelationship)}");

      for(var i = 0; i < ticketIdentities.Length; i++)
      {
        query.SetParameter(i, ticketIdentities[i].Value);
      }

      return query;
    }

    string GetQueryString(int identityCount)
    {
      var paramPlaceholders = Enumerable.Range(0, identityCount)
        .Select(x => "(?)")
        .ToArray();

      return $@"WITH RECURSIVE
  source_data(ticket_id) AS
  (
    VALUES {String.Join(",", paramPlaceholders)}
  ),
  descendents(ticket_id, related_ticket_id, direction, ticket_relationship_id, primary_ticket_id, secondary_ticket_id, relationship_id) AS
  (
    SELECT
      source_data.ticket_id,
      tr.secondary_ticket_id,
      'Descendent',
      tr.ticket_relationship_id,
      tr.primary_ticket_id,
      tr.secondary_ticket_id,
      tr.relationship_id
    FROM
      ticket_relationship AS tr
      INNER JOIN relationship AS r USING(relationship_id),
      source_data
    WHERE
      r.type = 'Directional'
      AND tr.primary_ticket_id = source_data.ticket_id
    UNION SELECT
      descendents.ticket_id,
      tr.secondary_ticket_id,
      'Descendent',
      tr.ticket_relationship_id,
      tr.primary_ticket_id,
      tr.secondary_ticket_id,
      tr.relationship_id
    FROM
      ticket_relationship AS tr
      INNER JOIN relationship AS r USING(relationship_id),
      descendents
    WHERE
      r.type = 'Directional'
      AND tr.primary_ticket_id = descendents.related_ticket_id
      AND tr.relationship_id = descendents.relationship_id
  ),
  ancestors(ticket_id, related_ticket_id, direction, ticket_relationship_id, primary_ticket_id, secondary_ticket_id, relationship_id) AS
  (
    SELECT
      source_data.ticket_id,
      tr.primary_ticket_id,
      'Ancestor',
      tr.ticket_relationship_id,
      tr.primary_ticket_id,
      tr.secondary_ticket_id,
      tr.relationship_id
    FROM
      ticket_relationship AS tr
      INNER JOIN relationship AS r USING(relationship_id),
      source_data
    WHERE
      r.type = 'Directional'
      AND tr.secondary_ticket_id = source_data.ticket_id
    UNION SELECT
      ancestors.ticket_id,
      tr.primary_ticket_id,
      'Ancestor',
      tr.ticket_relationship_id,
      tr.primary_ticket_id,
      tr.secondary_ticket_id,
      tr.relationship_id
    FROM
      ticket_relationship AS tr
      INNER JOIN relationship AS r USING(relationship_id),
      ancestors
    WHERE
      r.type = 'Directional'
      AND tr.secondary_ticket_id = ancestors.related_ticket_id
      AND tr.relationship_id = ancestors.relationship_id
  ),
  relationship_hierarchy(ticket_id, related_ticket_id, direction, ticket_relationship_id, primary_ticket_id, secondary_ticket_id, relationship_id) AS
  (
    SELECT
      ticket_id,
      related_ticket_id,
      direction,
      ticket_relationship_id,
      primary_ticket_id,
      secondary_ticket_id,
      relationship_id
    FROM descendents
    UNION SELECT
      ticket_id,
      related_ticket_id,
      direction,
      ticket_relationship_id,
      primary_ticket_id,
      secondary_ticket_id,
      relationship_id
    FROM ancestors
  )
SELECT
  ticket_relationship_id AS {{htr.IdentityValue}},
  ticket_id AS {{htr.{nameof(HierarchicalTicketRelationship.Ticket)}}},
  related_ticket_id AS {{htr.{nameof(HierarchicalTicketRelationship.RelatedTicket)}}},
  direction AS {{htr.{nameof(HierarchicalTicketRelationship.Direction)}}},
  ticket_relationship_id AS {{htr.{nameof(HierarchicalTicketRelationship.TicketRelationship)}}},
  ticket_relationship_id AS {{tr.IdentityValue}},
  relationship_id AS {{tr.{nameof(TicketRelationship.Relationship)}}},
  primary_ticket_id AS {{tr.{nameof(TicketRelationship.PrimaryTicket)}}},
  secondary_ticket_id AS {{tr.{nameof(TicketRelationship.SecondaryTicket)}}}
FROM relationship_hierarchy;";
    }

    public HierarchicalTicketRelationshipProvider(ISession session)
    {
      this.session = session ?? throw new ArgumentNullException(nameof(session));
    }
  }
}
