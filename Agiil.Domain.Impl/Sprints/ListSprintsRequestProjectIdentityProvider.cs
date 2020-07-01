using System;
using Agiil.Domain.Capabilities;
using Agiil.Domain.Projects;
using CSF.Entities;

namespace Agiil.Domain.Sprints
{
    public class ListSprintsRequestProjectIdentityProvider : IGetsTargetEntityIdentity<Project, ListSprintsRequest>
    {
        readonly IGetsCurrentProject projectProvider;

        public IIdentity<Project> GetTargetEntityIdentity(ListSprintsRequest value)
            => value.Project ?? projectProvider.GetCurrentProject().GetIdentity();

        public ListSprintsRequestProjectIdentityProvider(IGetsCurrentProject projectProvider)
        {
            this.projectProvider = projectProvider ?? throw new ArgumentNullException(nameof(projectProvider));
        }
    }
}
