using System;
using System.Collections.Generic;
using System.Reflection;

namespace Agiil.Domain.Capabilities
{
    public interface IGetsCapabilitiesAssertionsToPerform
    {
        IReadOnlyCollection<CapabilitiesAssertionSpec> GetAssertionsToPerform(MethodInfo method, object[] parameterValues);
    }
}
