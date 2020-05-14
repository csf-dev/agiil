using System;
using CSF.Entities;
using Agiil.Auth;

namespace Agiil.Domain.Auth
{
    public class User : Entity<long>
    {
        /// <summary>
        /// The user's login username, such as 'joesmith'.
        /// </summary>
        /// <value>The username.</value>
        public virtual string Username { get; set; }

        /// <summary>
        /// A serialized JSON object containing their credentials.
        /// </summary>
        /// <value>The serialized credentials.</value>
        public virtual string SerializedCredentials { get; set; }

        /// <summary>
        /// A flag which indicates whether or not the user is a site-wide administrator user.
        /// These super-admins have ultimate permissions to do anything in the whole app.
        /// </summary>
        /// <value><c>true</c> if this user is a site administrator; otherwise, <c>false</c>.</value>
        public virtual bool SiteAdministrator { get; set; }
    }
}
