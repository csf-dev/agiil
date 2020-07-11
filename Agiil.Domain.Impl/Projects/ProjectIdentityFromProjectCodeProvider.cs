using System;
using CSF.Entities;

namespace Agiil.Domain.Projects
{
    public class ProjectIdentityFromProjectCodeProvider : Capabilities.IGetsTargetEntityIdentity<Project,string>
    {
        readonly IGetsProject projectProvider;

        public IIdentity<Project> GetTargetEntityIdentity(string value)
            => projectProvider.GetProject(value)?.GetIdentity();

        public ProjectIdentityFromProjectCodeProvider(IGetsProject projectProvider)
        {
            this.projectProvider = projectProvider ?? throw new ArgumentNullException(nameof(projectProvider));
        }
    }
}
