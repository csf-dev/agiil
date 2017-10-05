using System;
using System.Collections.Generic;

namespace Agiil.Domain.Tickets
{
  public interface ITicketTypeProvider
  {
    IReadOnlyCollection<TicketType> GetTicketTypes();
  }
}
