using System;

namespace Agiil.Domain.Capabilities
{
    public class CapabilitiesAssertionSpec
    {
        public string ParameterName { get; }
        public Type ParameterType { get; }
        public object ParameterValue { get; }
        public RequireCapabilityAttribute CapabilityAttribute { get; }
        public string ActionName { get; }

        public CapabilitiesAssertionSpec(string parameterName,
                                         Type parameterType,
                                         object parameterValue,
                                         RequireCapabilityAttribute capabilityAttribute,
                                         string actionName)
        {
            ParameterName = parameterName ?? throw new ArgumentNullException(nameof(parameterName));
            ParameterType = parameterType ?? throw new ArgumentNullException(nameof(parameterType));
            ParameterValue = parameterValue;
            CapabilityAttribute = capabilityAttribute ?? throw new ArgumentNullException(nameof(capabilityAttribute));
            ActionName = actionName ?? throw new ArgumentNullException(nameof(actionName));
        }
    }
}
