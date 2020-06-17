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
        /// Edit a <see cref="Project"/>'s basic information, such as description, name &amp; code.
        /// </summary>
        EditProject         = 1 << 0,

        /// <summary>
        /// Delete the <see cref="Project"/>.
        /// </summary>
        DeleteProject       = 1 << 1,
    }
}
