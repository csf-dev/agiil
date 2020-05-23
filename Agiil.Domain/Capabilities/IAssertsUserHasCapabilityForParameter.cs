using System;
using System.Reflection;

namespace Agiil.Domain.Capabilities
{
    public interface IAssertsUserHasCapabilityForParameter
    {
        void AssertCurrentUserHasCapability(ParameterInfo parameter, object parameterValue, object requiredCapability);
    }
}
