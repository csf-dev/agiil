using System;
using Agiil.Domain.Capabilities;

namespace Agiil.Domain.Projects
{
    [EnforceCapabilities]
    public interface IGetsProject
    {
        Project GetProject([RequireCapability(ProjectCapability.View)] string code);
    }
}
