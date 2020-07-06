using System;
using System.Linq;
using Agiil.Domain.Auth;
using Agiil.Domain.Capabilities;
using CSF.Entities;
using CSF.ORM;

namespace Agiil.Domain.Projects
{
    public class ProjectCapabilitiesProvider : IGetsUserCapabilities<Project,ProjectCapability>
    {
        readonly IEntityData data;

        public ProjectCapability GetCapabilities(IIdentity<User> userIdentity, IIdentity<Project> targetEntity)
        {
            if(userIdentity == null)
                throw new ArgumentNullException(nameof(userIdentity));
            if(targetEntity == null) return 0;

            var user = GetUser(userIdentity);
            var project = data.Get(targetEntity);

            if(user == null || project == null)
                return 0;

            var isAContributor = user.ContributorTo.Contains(project);
            var isAProjectAdmin = user.AdministratorOf.Contains(project);
            var isASiteAdmin = user.SiteAdministrator;

            if(isASiteAdmin || isAProjectAdmin)
            {
                // IE: All of the capabilities!
                return Enum.GetValues(typeof(ProjectCapability))
                    .Cast<ProjectCapability>()
                    .Aggregate(default(ProjectCapability), (acc, next) => acc | next);
            }

            if(isAContributor)
            {
                return ProjectCapability.CreateTicket
                     | ProjectCapability.View
                     | ProjectCapability.ViewSprints
                     | ProjectCapability.ViewTickets;
            }

            return 0;
        }

        User GetUser(IIdentity<User> userIdentity)
        {
            var u = data.Theorise(userIdentity);
            return data.Query<User>()
                .Where(x => x == u)
                //.FetchChildren(x => x.ContributorTo)
                //.FetchChildren(x => x.AdministratorOf)
                // Must use ToList first, because otherwise the fetches won't work
                .ToList()
                .FirstOrDefault();
        }

        public ProjectCapabilitiesProvider(IEntityData data)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
