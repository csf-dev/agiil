using System;
using System.Collections.Generic;
using Agiil.Domain.Capabilities;
using Agiil.Domain.Projects;

namespace Agiil.Domain.Sprints
{
    [EnforceCapabilities]
    public interface ISprintLister
    {
        IList<Sprint> GetSprints([RequireCapability(ProjectCapability.ViewSprints)] ListSprintsRequest request);
    }
}
