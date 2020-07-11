using System;
using CSF.Entities;

namespace Agiil.Domain.Sprints
{
    public class SprintIdentityFromEditSprintRequestProvider : Capabilities.IGetsTargetEntityIdentity<Sprint,EditSprintRequest>
    {
        public IIdentity<Sprint> GetTargetEntityIdentity(EditSprintRequest value)
            => value.SprintIdentity;
    }
}
