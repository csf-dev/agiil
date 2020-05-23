using System;
using System.Linq.Expressions;
using Agiil.Domain.Auth;
using CSF.Specifications;

namespace Agiil.Domain.Projects
{
    public interface ISpecificationForProjectsWhichTheCurrentUserCanSeeInAList : ISpecificationExpression<Project> { }

    public class UserCanSeeProjectInList : ISpecificationForProjectsWhichTheCurrentUserCanSeeInAList
    {
        readonly ICurrentUserReader userProvider;
        readonly ISpecificationForSiteAdministrators siteAdminSpec;

        public Expression<Func<Project, bool>> GetExpression()
        {
            // This is really only temporary logic.  Right now it
            // means that only site admins can see lists of projects.
            // Later I can rewrite this.

            var user = userProvider.RequireCurrentUser();
            return project => siteAdminSpec.Matches(user);
        }

        public UserCanSeeProjectInList(ICurrentUserReader userProvider, ISpecificationForSiteAdministrators siteAdminSpec)
        {
            this.userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
            this.siteAdminSpec = siteAdminSpec ?? throw new ArgumentNullException(nameof(siteAdminSpec));
        }
    }
}
