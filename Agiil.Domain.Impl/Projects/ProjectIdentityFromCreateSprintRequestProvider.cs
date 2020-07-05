using System;
using Agiil.Domain.Sprints;
using CSF.Entities;

namespace Agiil.Domain.Projects
{
    public class ProjectIdentityFromCreateSprintRequestProvider : Capabilities.IGetsTargetEntityIdentity<Project, CreateSprintRequest>
    {
        readonly IGetsCurrentProject currentProjectProvider;

        public IIdentity<Project> GetTargetEntityIdentity(CreateSprintRequest value)
            => currentProjectProvider.GetCurrentProject()?.GetIdentity();

        public ProjectIdentityFromCreateSprintRequestProvider(IGetsCurrentProject currentProjectProvider)
        {
            this.currentProjectProvider = currentProjectProvider ?? throw new ArgumentNullException(nameof(currentProjectProvider));
        }
    }
}
