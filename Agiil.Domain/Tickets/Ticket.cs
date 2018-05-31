using System;
using System.Collections.Generic;
using Agiil.Domain.Auth;
using Agiil.Domain.Labels;
using CSF.Collections.EventRaising;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class Ticket : Entity<long>, IIdentifiesTicketByProjectAndNumber
  {
    readonly EventRaisingSetWrapper<Comment> comments;
    readonly EventRaisingSetWrapper<Label> labels;

    public virtual string Title { get; set; }

    public virtual string Description { get; set; }

    public virtual User User { get; set; }

    public virtual DateTime CreationTimestamp { get; set; }

    public virtual ISet<Comment> Comments {
      get { return comments.Collection; }
      protected set { /* no-op */ }
    }

    protected virtual ISet<Comment> SourceComments
    {
      get { return comments.SourceCollection; }
      set { comments.SourceCollection = value; }
    }

    [ManyToMany]
    public virtual ISet<Label> Labels {
      get { return labels.Collection; }
      protected set { /* no-op */ }
    }

    protected virtual ISet<Label> SourceLabels
    {
      get { return labels.SourceCollection; }
      set { labels.SourceCollection = value; }
    }

    public virtual Projects.Project Project { get; set; }

    public virtual Sprints.Sprint Sprint { get; set; }

    public virtual long TicketNumber { get; set; }

    public virtual bool Closed { get; set; }

    public virtual TicketType Type { get; set; }

    string IIdentifiesTicketByProjectAndNumber.ProjectCode => Project?.Code;

    public Ticket()
    {
      comments = new EventRaisingSetWrapper<Comment>(new HashSet<Comment>());
      comments.AfterAdd += (sender, e) => e.Item.Ticket = this;
      comments.AfterRemove += (sender, e) => e.Item.Ticket = null;

      labels = new EventRaisingSetWrapper<Label>(new HashSet<Label>());
      labels.AfterAdd += (sender, e) => {
        if(!e.Item.Tickets.Contains(this))
          e.Item.Tickets.Add(this);
      };
      labels.AfterRemove += (sender, e) => {
        if(e.Item.Tickets.Contains(this))
          e.Item.Tickets.Remove(this);
      };
    }
  }
}
