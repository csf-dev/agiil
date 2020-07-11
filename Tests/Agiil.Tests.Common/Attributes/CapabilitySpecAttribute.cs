using System;
using System.Reflection;
using Agiil.Domain.Capabilities;
using Agiil.Tests.Autofixture;
using AutoFixture;
using AutoFixture.NUnit3;

namespace Agiil.Tests.Attributes
{
    public class CapabilitySpecAttribute : CustomizeAttribute
    {
        public override ICustomization GetCustomization(ParameterInfo parameter)
        {
            if(!typeof(CapabilitiesAssertionSpec).IsAssignableFrom(parameter.ParameterType))
                throw new ArgumentException($"Parameter must be for an instance of {nameof(CapabilitiesAssertionSpec)}.", nameof(parameter));

            return new CapabilitySpecCustomization(parameter.ParameterType, parameter.Name);
        }

        [Flags]
        public enum SampleCapability
        {
            One     = 1 << 0,
            Two     = 1 << 1,
            Three   = 1 << 2,
            Four    = 1 << 3
        }
    }
}
