using System;
using System.Collections.Generic;
using Agiil.Domain.Tickets;
using CSF.Collections.EventRaising;
using CSF.Entities;

namespace Agiil.Domain.Labels
{
  public class Label : Entity<long>
  {
    readonly EventRaisingSetWrapper<Ticket> tickets;

    public virtual string Name { get; set; }

    [ManyToMany(false)]
    public virtual ISet<Ticket> Tickets
    {
      get { return tickets.Collection; }
      protected set { /* no-op */ }
    }

    protected virtual ISet<Ticket> SourceTickets
    {
      get { return tickets.SourceCollection; }
      set { tickets.SourceCollection = value; }
    }

    public Label()
    {
      tickets = new EventRaisingSetWrapper<Ticket>(new HashSet<Ticket>());

      tickets.AfterAdd += (sender, e) => {
        if(!e.Item.Labels.Contains(this))
          e.Item.Labels.Add(this);
      };
      tickets.AfterRemove += (sender, e) => {
        if(e.Item.Labels.Contains(this))
          e.Item.Labels.Remove(this);
      };
    }
  }
}
