using System;
using Agiil.Domain.Capabilities;
using Agiil.Domain.Projects;

namespace Agiil.Domain.Sprints
{
    [EnforceCapabilities]
    public interface ISprintCreator
    {
        CreateSprintResponse Create([RequireCapability(ProjectCapability.CreateSprint)] CreateSprintRequest request);
    }
}
