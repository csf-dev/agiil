using System;
using Agiil.Domain.Auth;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class Ticket : Entity<long>
  {
    public virtual string Title { get; set; }

    public virtual string Description { get; set; }

    public virtual User User { get; set; }

    public virtual DateTime CreationTimestamp { get; set; }
  }
}
