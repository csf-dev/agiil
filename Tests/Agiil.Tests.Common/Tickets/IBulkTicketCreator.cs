using System;
using System.Collections.Generic;

namespace Agiil.Tests.Tickets
{
  public interface IBulkTicketCreator
  {
    void CreateTickets(IEnumerable<BulkTicketSpecification> tickets);
  }
}
