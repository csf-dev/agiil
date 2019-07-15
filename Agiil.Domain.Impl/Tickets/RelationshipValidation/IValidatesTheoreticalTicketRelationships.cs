using System;
using System.Collections.Generic;
using CSF.Entities;

namespace Agiil.Domain.Tickets.RelationshipValidation
{
  public interface IValidatesTheoreticalTicketRelationships
  {
    bool AreRelationshipsValid(IIdentity<Ticket> editedTicket, IEnumerable<TheoreticalRelationship> relationships);
  }
}
