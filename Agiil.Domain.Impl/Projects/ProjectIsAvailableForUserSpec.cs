using System;
using System.Linq.Expressions;
using Agiil.Domain.Auth;
using CSF.Entities;
using CSF.ORM;
using CSF.Specifications;

namespace Agiil.Domain.Projects
{
    public interface ISpecForProjectsAvailableForAUser : ISpecificationExpression<Project> { }

    public class ProjectIsAvailableForUserSpec : ISpecForProjectsAvailableForAUser
    {
        readonly IEntityData data;
        readonly IIdentity<User> userId;

        public Expression<Func<Project, bool>> GetExpression()
        {
            var user = data.Theorise(userId);
            return project => user.SiteAdministrator
                              || project.Administrators.Contains(user)
                              || project.Contributors.Contains(user);
        }

        public ProjectIsAvailableForUserSpec(IIdentity<User> userId, IEntityData data)
        {
            this.userId = userId ?? throw new ArgumentNullException(nameof(userId));
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
