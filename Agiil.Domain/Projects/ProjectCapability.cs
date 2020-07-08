using System;
namespace Agiil.Domain.Projects
{
    /// <summary>
    /// Indicates the capabilities which are applicable to a <see cref="Project"/>.
    /// </summary>
    [Flags]
    public enum ProjectCapability
    {
        /// <summary>
        /// View the <see cref="Project"/> and its description.
        /// </summary>
        View            = 1 << 0,

        /// <summary>
        /// Edit a <see cref="Project"/>'s basic information, such as description, name &amp; code.
        /// </summary>
        Edit            = 1 << 1,

        /// <summary>
        /// Delete the <see cref="Project"/>.
        /// </summary>
        Delete          = 1 << 2,

        /// <summary>
        /// Create a new <see cref="Tickets.Ticket"/> in this <see cref="Project"/>.
        /// </summary>
        CreateTicket    = 1 << 3,

        /// <summary>
        /// View &amp; list all of the <see cref="Tickets.Ticket"/> objects in this <see cref="Project"/>.
        /// </summary>
        ViewTickets     = 1 << 4,

        /// <summary>
        /// Create a new <see cref="Sprints.Sprint"/> in this <see cref="Project"/>.
        /// </summary>
        CreateSprint    = 1 << 5,

        /// <summary>
        /// View &amp; list all of the <see cref="Sprints.Sprint"/> objects in this <see cref="Project"/>.
        /// </summary>
        ViewSprints     = 1 << 6,
    }
}
