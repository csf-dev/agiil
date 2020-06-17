using System;
namespace Agiil.Domain.App
{
    /// <summary>
    /// Indicates the capabilities which are applicable to an <see cref="AgiilApp"/>.
    /// </summary>
    [Flags]
    public enum AppCapability
    {
        /// <summary>
        /// Create a new <see cref="Projects.Project"/>.
        /// </summary>
        CreateProject = 1 << 0,
    }
}
