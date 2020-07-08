using System;
using Agiil.Domain.Capabilities;

namespace Agiil.Domain.Sprints
{
    [EnforceCapabilities]
    public interface ISprintEditor
    {
        EditSprintResponse Edit([RequireCapability(SprintCapability.Edit)] EditSprintRequest request);
    }
}
