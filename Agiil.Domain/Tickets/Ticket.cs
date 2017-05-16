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

    public virtual ISet<Comment> Comments => comments.Collection;

    protected virtual ISet<Comment> SourceComments
    {
      get { return comments.SourceCollection; }
      set { comments.SourceCollection = value; }
    }

    public Ticket()
    {
      comments = new EventRaisingSetWrapper<Comment>();
      comments.BeforeAdd += (sender, e) => e.Item.Ticket = this;
      comments.AfterRemove += (sender, e) => e.Item.Ticket = null;
    }
  }
}
