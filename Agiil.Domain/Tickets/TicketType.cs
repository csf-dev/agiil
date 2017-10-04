using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class TicketType : Entity<long>
  {
    public virtual string Name { get; set; }
  }
}
