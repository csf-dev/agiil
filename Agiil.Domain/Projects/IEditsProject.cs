using System;
using Agiil.Domain.Capabilities;

namespace Agiil.Domain.Projects
{
    [EnforceCapabilities]
    public interface IEditsProject
    {
        EditProjectResponse EditProject([RequireCapability(ProjectCapability.Edit)] EditProjectRequest request);
    }
}
