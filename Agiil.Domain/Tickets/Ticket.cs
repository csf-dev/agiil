using System;
using System.Collections.Generic;
using Agiil.Domain.Auth;
using CSF.Collections.EventRaising;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class Ticket : Entity<long>
  {
    readonly EventRaisingSetWrapper<Comment> comments;

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

    public virtual Projects.Project Project { get; set; }

    public virtual Sprints.Sprint Sprint { get; set; }

    public virtual long TicketNumber { get; set; }

    public virtual bool Closed { get; set; }

    [Obsolete("Instead use an instance of `ITicketReferenceParser' to get the reference.")]
    public virtual string GetTicketReference()
    {
      return String.Concat(Project?.Code, TicketNumber.ToString());
    }

    public Ticket()
    {
      comments = new EventRaisingSetWrapper<Comment>(new HashSet<Comment>());
      comments.BeforeAdd += (sender, e) => e.Item.Ticket = this;
      comments.BeforeRemove += (sender, e) => e.Item.Ticket = null;
    }
  }
}
