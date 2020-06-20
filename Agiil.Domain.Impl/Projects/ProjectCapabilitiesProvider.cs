using System;
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

            var user = data.Get(userIdentity);
            if(user.SiteAdministrator)
                return ProjectCapability.EditProject | ProjectCapability.DeleteProject;

            return default;
        }

        public ProjectCapabilitiesProvider(IEntityData data)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
