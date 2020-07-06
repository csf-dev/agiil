using System;
using Agiil.Domain.Auth;
using Agiil.Domain.Capabilities;
using CSF.Entities;
using CSF.ORM;

namespace Agiil.Domain.App
{
    public class AppCapabilitiesProvider : IGetsUserCapabilities<AgiilApp, AppCapability>
    {
        readonly IEntityData data;

        public AppCapability GetCapabilities(IIdentity<User> userIdentity, IIdentity<AgiilApp> targetEntity)
        {
            if(userIdentity == null)
                throw new ArgumentNullException(nameof(userIdentity));

            var user = data.Get(userIdentity);
            if(user.SiteAdministrator)
                return AppCapability.CreateProject;

            return 0;
        }

        public AppCapabilitiesProvider(IEntityData data)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
