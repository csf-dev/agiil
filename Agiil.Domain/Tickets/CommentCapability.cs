using System;
namespace Agiil.Domain.Tickets
{
    /// <summary>
    /// The various capabilities which a user may have for a comment.
    /// </summary>
    [Flags]
    public enum CommentCapability
    {
        /// <summary>
        /// The user may edit the comment.
        /// </summary>
        Edit        = 1 << 0,

        /// <summary>
        /// The user may delete the comment.
        /// </summary>
        Delete      = 1 << 1,
    }
}
