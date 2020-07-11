using System;
using Agiil.Domain.App;
using Agiil.Domain.Capabilities;
using CSF.Entities;

namespace Agiil.Domain.Projects
{
    public class AppIdentityProvider : IGetsTargetEntityIdentity<AgiilApp, CreateProjectRequest>
    {
        public IIdentity<AgiilApp> GetTargetEntityIdentity(CreateProjectRequest value)
            => AgiilApp.Instance.GetIdentity();
    }
}
