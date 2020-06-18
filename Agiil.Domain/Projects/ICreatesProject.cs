using System;
using Agiil.Domain.Capabilities;
using static Agiil.Domain.App.AppCapability;

namespace Agiil.Domain.Projects
{
    [EnforceCapabilities]
    public interface ICreatesProject
    {
        Project CreateNewProject([RequireCapability(CreateProject)] CreateProjectRequest request);
    }
}
