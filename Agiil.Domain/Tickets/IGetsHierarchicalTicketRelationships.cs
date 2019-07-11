using System;
using System.Collections.Generic;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public interface IGetsHierarchicalTicketRelationships
  {
    IEnumerable<HierarchicalTicketRelationship> GetRelationships(params IIdentity<Ticket>[] ticketIdentities);
  }
}
