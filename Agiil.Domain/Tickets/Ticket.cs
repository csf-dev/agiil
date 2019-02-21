using System;
using System.Collections.Generic;
using System.Linq;
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
    readonly EventRaisingSetWrapper<TicketRelationship> primaryRelationships, secondaryRelationships;

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

    public virtual ISet<TicketRelationship> PrimaryRelationships {
      get { return primaryRelationships.Collection; }
      protected set { /* no-op */ }
    }

    protected virtual ISet<TicketRelationship> SourcePrimaryRelationships
    {
      get { return primaryRelationships.SourceCollection; }
      set { primaryRelationships.SourceCollection = value; }
    }

    public virtual ISet<TicketRelationship> SecondaryRelationships {
      get { return secondaryRelationships.Collection; }
      protected set { /* no-op */ }
    }

    protected virtual ISet<TicketRelationship> SourceSecondaryRelationships
    {
      get { return secondaryRelationships.SourceCollection; }
      set { secondaryRelationships.SourceCollection = value; }
    }

    public virtual Projects.Project Project { get; set; }

    public virtual Sprints.Sprint Sprint { get; set; }

    public virtual long TicketNumber { get; set; }

    public virtual bool Closed { get; set; }

    public virtual TicketType Type { get; set; }

    public virtual int? StoryPoints { get; set; }

    public virtual IReadOnlyCollection<TicketRelationship> GetAllRelationships()
    {
      return PrimaryRelationships
        .Union(SecondaryRelationships)
        .ToArray();
    }

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

      primaryRelationships = new EventRaisingSetWrapper<TicketRelationship>(new HashSet<TicketRelationship>());
      primaryRelationships.AfterAdd += (sender, e) => e.Item.PrimaryTicket = this;
      primaryRelationships.AfterRemove += (sender, e) => e.Item.PrimaryTicket = null;

      secondaryRelationships = new EventRaisingSetWrapper<TicketRelationship>(new HashSet<TicketRelationship>());
      secondaryRelationships.AfterAdd += (sender, e) => e.Item.SecondaryTicket = this;
      secondaryRelationships.AfterRemove += (sender, e) => e.Item.SecondaryTicket = null;
    }
  }
}
