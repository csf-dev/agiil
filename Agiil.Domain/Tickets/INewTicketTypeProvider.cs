using System;
using System.Collections.Generic;

namespace Agiil.Domain.Tickets
{
  public interface INewTicketTypeProvider
  {
    IReadOnlyCollection<TicketType> GetTicketTypes();
  }
}
