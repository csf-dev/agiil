using System;
using System.Collections.Generic;
using Agiil.Domain.Tickets;
using CSF.Collections.EventRaising;
using CSF.Entities;

namespace Agiil.Domain.Labels
{
  public class Label : Entity<long>
  {
    public virtual string Name { get; set; }

    readonly EventRaisingSetWrapper<Ticket> tickets;
    [ManyToMany(false)]
    public virtual ISet<Ticket> Tickets
    {
      get { return tickets.Collection; }
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
