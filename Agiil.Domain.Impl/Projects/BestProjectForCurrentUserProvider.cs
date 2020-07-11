using System;
using System.Linq;
using Agiil.Domain.Auth;
using CSF.ORM;

namespace Agiil.Domain.Projects
{
    /// <summary>
    /// This implementation attempts to pick the 'best' project for the current user.
    /// Projects for which the current user is an administrator get priority, followed by those for which the user is a contributor.
    /// If there is still a tie, then the project with the first name (in lexical alphabetical order) is chosen.
    /// </summary>
    public class BestProjectForCurrentUserProvider : IGetsCurrentProject
    {
        readonly IEntityData data;
        readonly ICurrentUserReader userReader;

        public Project GetCurrentProject()
        {
            var user = userReader.RequireCurrentUser();

            return (from project in data.Query<Project>()
                    let priority = project.Administrators.Contains(user)
                                   ? 0
                                   : project.Contributors.Contains(user)
                                   ? 1
                                   : 2
                    orderby priority, project.Name
                    select project)
                .FirstOrDefault();
        }

        public BestProjectForCurrentUserProvider(IEntityData data, ICurrentUserReader userReader)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
            this.userReader = userReader ?? throw new ArgumentNullException(nameof(userReader));
        }
    }
}
