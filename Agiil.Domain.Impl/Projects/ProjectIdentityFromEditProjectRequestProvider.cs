using System;
using Agiil.Domain.Capabilities;
using CSF.Entities;

namespace Agiil.Domain.Projects
{
    public class ProjectIdentityFromEditProjectRequestProvider : IGetsTargetEntityIdentity<Project,EditProjectRequest>
    {
        public IIdentity<Project> GetTargetEntityIdentity(EditProjectRequest value)
            => value?.Identity;
    }
}
