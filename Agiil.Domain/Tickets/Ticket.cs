using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class Ticket : Entity<long>
  {
    public virtual string Title { get; set; }

    public virtual string Description { get; set; }
  }
}
