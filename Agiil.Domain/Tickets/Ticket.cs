using System;
using System.Collections.Generic;
using System.Linq;
using CSF.Collections.EventRaising;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class Ticket : Entity<long>, IIdentifiesTicketByProjectAndNumber
  {
    public virtual string Title { get; set; }

    public virtual string Description { get; set; }

    public virtual DateTime CreationTimestamp { get; set; }

    public virtual long TicketNumber { get; set; }

    public virtual bool Closed { get; set; }

    public virtual int? StoryPoints { get; set; }

    #region Comments

    readonly EventRaisingSetWrapper<Comment> comments;

    public virtual ISet<Comment> Comments {
      get { return comments.Collection; }
      protected set { /* no-op */ }
    }

    protected virtual ISet<Comment> SourceComments
    {
      get { return comments.SourceCollection; }
      set { comments.SourceCollection = value; }
    }

    #endregion

    #region Labels

    readonly EventRaisingSetWrapper<Labels.Label> labels;

    [ManyToMany]
    public virtual ISet<Labels.Label> Labels {
      get { return labels.Collection; }
      protected set { /* no-op */ }
    }

    protected virtual ISet<Labels.Label> SourceLabels
    {
      get { return labels.SourceCollection; }
      set { labels.SourceCollection = value; }
    }

    #endregion

    #region PrimaryRelationships

    readonly EventRaisingSetWrapper<TicketRelationship> primaryRelationships;

    public virtual ISet<TicketRelationship> PrimaryRelationships {
      get { return primaryRelationships.Collection; }
      protected set { /* no-op */ }
    }

    protected virtual ISet<TicketRelationship> SourcePrimaryRelationships
    {
      get { return primaryRelationships.SourceCollection; }
      set { primaryRelationships.SourceCollection = value; }
    }

    #endregion

    #region SecondaryRelationships

    readonly EventRaisingSetWrapper<TicketRelationship> secondaryRelationships;

    public virtual ISet<TicketRelationship> SecondaryRelationships {
      get { return secondaryRelationships.Collection; }
      protected set { /* no-op */ }
    }

    protected virtual ISet<TicketRelationship> SourceSecondaryRelationships
    {
      get { return secondaryRelationships.SourceCollection; }
      set { secondaryRelationships.SourceCollection = value; }
    }

    #endregion

    #region WorkLogs

    readonly EventRaisingSetWrapper<Activity.TicketWorkLog> workLogs;

    public virtual ISet<Activity.TicketWorkLog> WorkLogs {
      get { return workLogs.Collection; }
      protected set { /* no-op */ }
    }

    protected virtual ISet<Activity.TicketWorkLog> SourceWorkLogs
    {
      get { return workLogs.SourceCollection; }
      set { workLogs.SourceCollection = value; }
    }

    #endregion

    public virtual Auth.User User { get; set; }

    public virtual Projects.Project Project { get; set; }

    public virtual Sprints.Sprint Sprint { get; set; }

    public virtual TicketType Type { get; set; }

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

      labels = new EventRaisingSetWrapper<Labels.Label>(new HashSet<Labels.Label>());
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

      workLogs = new EventRaisingSetWrapper<Activity.TicketWorkLog>(new HashSet<Activity.TicketWorkLog>());
      workLogs.AfterAdd += (sender, e) => e.Item.Ticket = this;
      workLogs.AfterRemove += (sender, e) => e.Item.Ticket = null;
    }
  }
}
