using System;
using Agiil.Domain.Auth;
using CSF.Entities;

namespace Agiil.Domain.Capabilities
{
    public class CurrentLoggedInUserCapabilityUserAdapter : IGetsCurrentCapabilityUser
    {
        readonly IIdentityReader identityReader;

        public IIdentity<User> GetCurrentCapabilityUser() => identityReader.GetCurrentUserInfo()?.Identity;

        public CurrentLoggedInUserCapabilityUserAdapter(IIdentityReader identityReader)
        {
            this.identityReader = identityReader ?? throw new ArgumentNullException(nameof(identityReader));
        }
    }
}
