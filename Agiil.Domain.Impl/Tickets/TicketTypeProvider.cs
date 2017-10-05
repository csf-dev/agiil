using System;
using System.Collections.Generic;
using System.Linq;
using CSF.Data.Entities;

namespace Agiil.Domain.Tickets
{
  public class TicketTypeProvider : ITicketTypeProvider
  {
    readonly IEntityData data;

    public IReadOnlyCollection<TicketType> GetTicketTypes() => data.Query<TicketType>().ToArray();

    public TicketTypeProvider(IEntityData data)
    {
      if(data == null)
        throw new ArgumentNullException(nameof(data));
      this.data = data;
    }
  }
}
