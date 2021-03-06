﻿using System;
using System.Collections.Generic;
using Agiil.Domain.Projects;
using Agiil.Domain.Tickets;
using CSF.Collections.EventRaising;
using CSF.Entities;

namespace Agiil.Domain.Sprints
{
  public class Sprint : Entity<long>
  {
    public virtual string Name { get; set; }

    [AllowNull]
    public virtual string Description { get; set; }

    public virtual Project Project { get; set; }

    public virtual DateTime CreationDate { get; set; }

    public virtual DateTime? StartDate { get; set; }

    public virtual DateTime? EndDate { get; set; }

    public virtual bool Closed { get; set; }

    readonly EventRaisingSetWrapper<Ticket> tickets;
    public virtual ISet<Ticket> Tickets {
      get { return tickets.Collection; }
    }

    public Sprint()
    {
      tickets = new EventRaisingSetWrapper<Ticket>(new HashSet<Ticket>());
      tickets.BeforeAdd += (sender, e) => e.Item.Sprint = this;
      tickets.BeforeRemove += (sender, e) => e.Item.Sprint = null;
    }
  }
}
