using System;
using Agiil.Domain.Capabilities;
using CSF.Entities;

namespace Agiil.Domain.Sprints
{
    [EnforceCapabilities]
    public interface ISprintDetailService
    {
        Sprint GetSprint([RequireCapability(SprintCapability.View)] IIdentity<Sprint> identity);
    }
}
