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

    public virtual string Name { get; set; }

    public virtual string Code { get; set; }

    public virtual long NextAvailableTicketNumber { get; set; }

    readonly EventRaisingSetWrapper<Ticket> tickets;
    public virtual ISet<Ticket> Tickets {
      get { return tickets.Collection; }
    }

    readonly EventRaisingSetWrapper<Sprint> sprints;
    public virtual ISet<Sprint> Sprints {
      get { return sprints.Collection; }
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
