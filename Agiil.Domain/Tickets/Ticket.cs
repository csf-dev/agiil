using System;
using System.Collections.Generic;
using System.Linq;
using CSF.Collections.EventRaising;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
    public class Ticket : Entity<long>
    {
        public virtual string Title { get; set; }

        [AllowNull]
        public virtual string Description { get; set; }

        public virtual DateTime CreationTimestamp { get; set; }

        public virtual long TicketNumber { get; set; }

        public virtual bool Closed { get; set; }

        public virtual int? StoryPoints { get; set; }

        readonly EventRaisingSetWrapper<Comment> comments;
        public virtual ISet<Comment> Comments => comments.Collection;

        readonly EventRaisingSetWrapper<Labels.Label> labels;
        [ManyToMany]
        public virtual ISet<Labels.Label> Labels => labels.Collection;

        readonly EventRaisingSetWrapper<TicketRelationship> primaryRelationships;
        public virtual ISet<TicketRelationship> PrimaryRelationships => primaryRelationships.Collection;

        readonly EventRaisingSetWrapper<TicketRelationship> secondaryRelationships;
        public virtual ISet<TicketRelationship> SecondaryRelationships => secondaryRelationships.Collection;

        readonly EventRaisingSetWrapper<Activity.TicketWorkLog> workLogs;
        public virtual ISet<Activity.TicketWorkLog> WorkLogs => workLogs.Collection;

        public virtual Auth.User User { get; set; }

        public virtual Projects.Project Project { get; set; }

        [AllowNull]
        public virtual Sprints.Sprint Sprint { get; set; }

        public virtual TicketType Type { get; set; }

        public virtual IReadOnlyCollection<TicketRelationship> GetAllRelationships()
        {
            return PrimaryRelationships
              .Union(SecondaryRelationships)
              .ToArray();
        }

        public virtual TicketReference GetTicketReference()
        {
            return new TicketReference(Project?.Code, TicketNumber);
        }

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
