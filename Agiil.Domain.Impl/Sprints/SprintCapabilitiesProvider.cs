using System;
using System.Linq;
using Agiil.Domain.Auth;
using Agiil.Domain.Capabilities;
using CSF.Entities;
using CSF.ORM;

namespace Agiil.Domain.Sprints
{
    public class SprintCapabilitiesProvider : IGetsUserCapabilities<Sprint, SprintCapability>
    {
        readonly IEntityData data;

        public SprintCapability GetCapabilities(IIdentity<User> userIdentity, IIdentity<Sprint> targetEntity)
        {
            if(userIdentity == null)
                throw new ArgumentNullException(nameof(userIdentity));
            if(targetEntity == null) return 0;

            var user = GetUser(userIdentity);
            var sprint = GetSprint(targetEntity);

            if(user == null || sprint == null)
                return 0;

            var isProjectContributor = user.ContributorTo.Contains(sprint.Project);
            var isProjectAdmin = user.AdministratorOf.Contains(sprint.Project);
            var isASiteAdmin = user.SiteAdministrator;

            if(isProjectAdmin || isASiteAdmin)
            {
                // IE: All of the capabilities!
                return Enum.GetValues(typeof(SprintCapability))
                    .Cast<SprintCapability>()
                    .Aggregate(default(SprintCapability), (acc, next) => acc | next);
            }

            if(isProjectContributor)
                return SprintCapability.View;

            return 0;
        }

        User GetUser(IIdentity<User> identity)
        {
            var u = data.Theorise(identity);
            return data.Query<User>()
                .Where(x => x == u)
                .FetchChildren(x => x.ContributorTo)
                .FetchChildren(x => x.AdministratorOf)
                // Must use ToList first, because otherwise the fetches won't work
                .ToList()
                .FirstOrDefault();
        }

        Sprint GetSprint(IIdentity<Sprint> identity)
        {
            var t = data.Theorise(identity);
            return data.Query<Sprint>()
                .Where(x => x == t)
                .FetchChild(x => x.Project)
                .FirstOrDefault();
        }

        public SprintCapabilitiesProvider(IEntityData data)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
