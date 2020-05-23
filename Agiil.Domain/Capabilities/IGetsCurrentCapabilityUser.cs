using System;
using Agiil.Domain.Auth;
using CSF.Entities;

namespace Agiil.Domain.Capabilities
{
    public interface IGetsCurrentCapabilityUser
    {
        IIdentity<User> GetCurrentCapabilityUser();
    }
}
