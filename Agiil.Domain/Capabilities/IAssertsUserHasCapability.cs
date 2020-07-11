using System;
using System.Reflection;

namespace Agiil.Domain.Capabilities
{
    public interface IAssertsUserHasCapability
    {
        void AssertCurrentUserHasCapability(CapabilitiesAssertionSpec assertionSpec);
    }
}
