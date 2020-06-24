using System;
using CSF.Entities;
using System.Collections.Generic;
using CSF.Collections.EventRaising;

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

        /// <summary>
        /// Gets a collection of the <see cref="Projects.Project"/> that this user is a contributor towards.
        /// </summary>
        /// <value>The projects for which the user is a contributor.</value>
        [ManyToMany(true)]
        public virtual ISet<Projects.Project> ContributorTo => contributorTo.Collection;
        readonly EventRaisingSetWrapper<Projects.Project> contributorTo;

        /// <summary>
        /// Gets a collection of the <see cref="Projects.Project"/> that this user is an administrator for.
        /// </summary>
        /// <value>The projects for which the user is an administrator.</value>
        [ManyToMany(true)]
        public virtual ISet<Projects.Project> AdministratorOf => administratorOf.Collection;
        readonly EventRaisingSetWrapper<Projects.Project> administratorOf;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            contributorTo = new EventRaisingSetWrapper<Projects.Project>(new HashSet<Projects.Project>());
            contributorTo.BeforeAdd += (sender, e) => {
                if(!e.Item.Contributors.Contains(this))
                    e.Item.Contributors.Add(this);
            };
            contributorTo.BeforeRemove += (sender, e) => {
                if(e.Item.Contributors.Contains(this))
                    e.Item.Contributors.Remove(this);
            };

            administratorOf = new EventRaisingSetWrapper<Projects.Project>(new HashSet<Projects.Project>());
            administratorOf.BeforeAdd += (sender, e) => {
                if(!e.Item.Administrators.Contains(this))
                    e.Item.Administrators.Add(this);
            };
            administratorOf.BeforeRemove += (sender, e) => {
                if(e.Item.Administrators.Contains(this))
                    e.Item.Administrators.Remove(this);
            };
        }
    }
}
