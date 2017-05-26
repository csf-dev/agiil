using System;
using System.Collections.Generic;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using CSF.Collections.EventRaising;
using CSF.Entities;

namespace Agiil.Domain.Projects
{
  public class Project : Entity<long>
  {
    readonly EventRaisingSetWrapper<Sprint> sprints;
    readonly EventRaisingSetWrapper<Ticket> tickets;

    public virtual string Name { get; set; }

    public virtual string Code { get; set; }

    public virtual long NextAvailableTicketNumber { get; set; }

    public virtual ISet<Ticket> Tickets {
      get { return tickets.Collection; }
      protected set { /* no-op */ }
    }

    protected virtual ISet<Ticket> SourceTickets
    {
      get { return tickets.SourceCollection; }
      set { tickets.SourceCollection = value; }
    }

    public virtual ISet<Sprint> Sprints {
      get { return sprints.Collection; }
      protected set { /* no-op */ }
    }

    protected virtual ISet<Sprint> SourceSprints
    {
      get { return sprints.SourceCollection; }
      set { sprints.SourceCollection = value; }
    }

    public Project()
    {
      tickets = new EventRaisingSetWrapper<Ticket>(new HashSet<Ticket>());
      tickets.BeforeAdd += (sender, e) => e.Item.Project = this;
      tickets.BeforeRemove += (sender, e) => e.Item.Project = null;

      sprints = new EventRaisingSetWrapper<Sprint>(new HashSet<Sprint>());
      sprints.BeforeAdd += (sender, e) => e.Item.Project = this;
      sprints.BeforeRemove += (sender, e) => e.Item.Project = null;
    }
  }
}
