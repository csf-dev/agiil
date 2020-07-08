using System;
namespace Agiil.Domain.Sprints
{
    [Flags]
    public enum SprintCapability
    {
        /// <summary>
        /// The user may view the sprint and see its description and the tickets within.
        /// </summary>
        View = 1 << 0,

        /// <summary>
        /// The user may edit the sprint details.
        /// </summary>
        Edit = 1 << 1,
    }
}
