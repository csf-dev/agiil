using System;
namespace Agiil.Domain
{
    /// <summary>
    /// Lists the keys used for transient data which exists for the lifetime of the user's session using the app.
    /// </summary>
    public sealed class SessionKey
    {
        /// <summary>
        /// Gets the key for storing the identity of the current <see cref="Projects.Project"/>.
        /// </summary>
        public static readonly string CurrentProjectIdentity = "Current project identity";
    }
}
