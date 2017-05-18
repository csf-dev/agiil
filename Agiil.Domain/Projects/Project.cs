using System;
using CSF.Entities;

namespace Agiil.Domain.Projects
{
  public class Project : Entity<long>
  {
    public virtual string Name { get; set; }

    public virtual string Code { get; set; }

    public virtual long NextAvailableTicketNumber { get; set; }
  }
}
