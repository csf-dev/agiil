using System;
using Agiil.Domain.Capabilities;
using CSF.Entities;

namespace Agiil.Domain.Projects
{
    [EnforceCapabilities]
    public interface ISetsCurrentProject
    {
        void SetCurrentProject([RequireCapability(ProjectCapability.View)] IIdentity<Project> projectId);
    }
}
