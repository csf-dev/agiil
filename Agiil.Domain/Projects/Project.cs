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
        public virtual string Code { get; set; }

        /// <summary>
        /// Gets the next available ticket number from which a <see cref="TicketReference"/> may be formed.
        /// </summary>
        /// <value>The next available ticket number.</value>
        public virtual long NextAvailableTicketNumber { get; set; }

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

        public Project()
        {
            tickets = new EventRaisingSetWrapper<Ticket>(new HashSet<Ticket>());
            tickets.BeforeAdd += (sender, e) => e.Item.Project = this;
            tickets.BeforeRemove += (sender, e) => e.Item.Project = null;

            sprints = new EventRaisingSetWrapper<Sprint>(new HashSet<Sprint>());
            sprints.BeforeAdd += (sender, e) => e.Item.Project = this;
            sprints.BeforeRemove += (sender, e) => e.Item.Project = null;

            description = String.Empty;
        }
    }
}
