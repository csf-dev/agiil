using System;
using System.Linq.Expressions;
using Agiil.Domain.Auth;
using CSF.Entities;
using CSF.Specifications;

namespace Agiil.Domain.Projects
{
    public interface ISpecificationForProjectsWhichTheCurrentUserCanSeeInAList : ISpecificationExpression<Project> { }

    public class UserCanSeeProjectInList : ISpecificationForProjectsWhichTheCurrentUserCanSeeInAList
    {
        readonly ICurrentUserReader userProvider;
        readonly Func<IIdentity<User>, ISpecForProjectsAvailableForAUser> availableProjectsSpecFactory;

        public Expression<Func<Project, bool>> GetExpression()
        {
            var user = userProvider.RequireCurrentUser();
            var availableProjectsSpec = availableProjectsSpecFactory(user.GetIdentity());
            return availableProjectsSpec.GetExpression();
        }

        public UserCanSeeProjectInList(ICurrentUserReader userProvider, Func<IIdentity<User>,ISpecForProjectsAvailableForAUser> availableProjectsSpecFactory)
        {
            this.userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
            this.availableProjectsSpecFactory = availableProjectsSpecFactory ?? throw new ArgumentNullException(nameof(availableProjectsSpecFactory));
        }
    }
}
