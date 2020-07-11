using System;
using Agiil.Domain.Tickets;
using CSF.Entities;

namespace Agiil.Domain.Projects
{
    public class ProjectIdentityFromCreateTicketRequestProvider : Capabilities.IGetsTargetEntityIdentity<Project,CreateTicketRequest>
    {
        readonly IGetsCurrentProject projectProvider;

        public IIdentity<Project> GetTargetEntityIdentity(CreateTicketRequest value)
            => projectProvider.GetCurrentProject()?.GetIdentity();

        public ProjectIdentityFromCreateTicketRequestProvider(IGetsCurrentProject projectProvider)
        {
            this.projectProvider = projectProvider ?? throw new ArgumentNullException(nameof(projectProvider));
        }
    }
}
