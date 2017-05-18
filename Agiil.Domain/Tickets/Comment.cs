using System;
using Agiil.Domain.Auth;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class Comment : Entity<long>
  {
    public virtual Ticket Ticket { get; set; }

    public virtual DateTime CreationTimestamp { get; set; }

    public virtual DateTime LastEditTimestamp { get; set; }

    public virtual User User { get; set; }

    public virtual string Body { get; set; }
  }
}
