using System;
using System.Reflection;
using Agiil.Domain.Capabilities;
using AutoFixture.Kernel;
using AutoFixture;
using Agiil.Tests.Attributes;

namespace Agiil.Tests.Autofixture
{
    public class CapabilitySpecSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if(!(request is ParameterInfo param))
                return new NoSpecimen();
            if(!typeof(CapabilitiesAssertionSpec).IsAssignableFrom(param.ParameterType))
                return new NoSpecimen();

            return new CapabilitiesAssertionSpec(context.Create<string>(),
                                                 context.Create<Type>(),
                                                 context.Create<object>(),
                                                 new RequireCapabilityAttribute(context.Create<CapabilitySpecAttribute.SampleCapability>()),
                                                 context.Create<string>());
        }
    }
}
