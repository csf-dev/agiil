using System;
namespace Agiil.Domain.Tickets
{
    [Flags]
    public enum TicketCapability
    {
        /// <summary>
        /// View the ticket.
        /// </summary>
        View        = 1 << 0,

        /// <summary>
        /// Edit the ticket.
        /// </summary>
        Edit        = 1 << 1,

        /// <summary>
        /// Delete the ticket.
        /// </summary>
        Delete      = 1 << 2,

        /// <summary>
        /// Add a new comment to the ticket.
        /// </summary>
        AddComment  = 1 << 3,
    }
}
