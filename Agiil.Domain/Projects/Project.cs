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
        public static readonly int
            MinCodeLength = 2,
            MaxCodeLength = 10;

        /// <summary>
        /// The human-readable name of the project.  This is intended to be quite short, such as one line.
        /// </summary>
        /// <value>The name.</value>
        public virtual string Name { get; set; }

        /// <summary>
        /// A short (few characters) code assigned to this project, to
        /// differentiate it from others on the same application site.
        /// The project code is used in <see cref="TicketReference"/> instances.
        /// </summary>
        /// <value>The project code.</value>
        public virtual string Code { get => code; set => code = value?.ToUpperInvariant(); }
        string code;

        /// <summary>
        /// Gets the next available ticket number from which a <see cref="TicketReference"/> may be formed.
        /// </summary>
        /// <value>The next available ticket number.</value>
        public virtual long NextAvailableTicketNumber { get => nextAvailableTicketNumber; set => nextAvailableTicketNumber = value; }
        long nextAvailableTicketNumber;

        /// <summary>
        /// A markdown-rendered free-text description of the project.
        /// </summary>
        /// <value>The description.</value>
        public virtual string Description { get => description; set => description = value; }
        string description;

        /// <summary>
        /// Gets a collection of the tickets in this project.
        /// </summary>
        /// <value>The tickets.</value>
        public virtual ISet<Ticket> Tickets => tickets.Collection;
        readonly EventRaisingSetWrapper<Ticket> tickets;

        /// <summary>
        /// Gets a collection of the sprints in this project.
        /// </summary>
        /// <value>The sprints.</value>
        public virtual ISet<Sprint> Sprints => sprints.Collection;
        readonly EventRaisingSetWrapper<Sprint> sprints;

        /// <summary>
        /// Gets a collection of the <see cref="Auth.User"/> objects which are a contributor to this project.
        /// </summary>
        /// <value>The contributors.</value>
        [ManyToMany(false)]
        public virtual ISet<Auth.User> Contributors => contributors.Collection;
        readonly EventRaisingSetWrapper<Auth.User> contributors;

        /// <summary>
        /// Gets a collection of the <see cref="Auth.User"/> objects which are administrators of this project.
        /// </summary>
        /// <value>The administrators.</value>
        [ManyToMany(false)]
        public virtual ISet<Auth.User> Administrators => administrators.Collection;
        readonly EventRaisingSetWrapper<Auth.User> administrators;

        public Project()
        {
            tickets = new EventRaisingSetWrapper<Ticket>(new HashSet<Ticket>());
            tickets.BeforeAdd += (sender, e) => e.Item.Project = this;
            tickets.BeforeRemove += (sender, e) => e.Item.Project = null;

            sprints = new EventRaisingSetWrapper<Sprint>(new HashSet<Sprint>());
            sprints.BeforeAdd += (sender, e) => e.Item.Project = this;
            sprints.BeforeRemove += (sender, e) => e.Item.Project = null;

            contributors = new EventRaisingSetWrapper<Auth.User>(new HashSet<Auth.User>());
            contributors.AfterAdd += (sender, e) => {
                if(!e.Item.ContributorTo.Contains(this))
                    e.Item.ContributorTo.Add(this);
            };
            contributors.AfterRemove += (sender, e) => {
                if(e.Item.ContributorTo.Contains(this))
                    e.Item.ContributorTo.Remove(this);
            };

            administrators = new EventRaisingSetWrapper<Auth.User>(new HashSet<Auth.User>());
            administrators.AfterAdd += (sender, e) => {
                if(!e.Item.AdministratorOf.Contains(this))
                    e.Item.AdministratorOf.Add(this);
            };
            administrators.AfterRemove += (sender, e) => {
                if(e.Item.AdministratorOf.Contains(this))
                    e.Item.AdministratorOf.Remove(this);
            };

            description = String.Empty;
            nextAvailableTicketNumber = 1;
        }
    }
}
