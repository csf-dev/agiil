using System;
using AutoFixture;
using AutoFixture.Kernel;

namespace Agiil.Tests.Autofixture
{
    public class CapabilitySpecCustomization : ICustomization
    {
        readonly Type paramType;
        readonly string paramName;

        public void Customize(IFixture fixture)
        {
            var spec = new ParameterSpecification(paramType, paramName);
            fixture.Customizations.Add(new FilteringSpecimenBuilder(new CapabilitySpecSpecimenBuilder(), spec));
        }

        public CapabilitySpecCustomization(Type paramType, string paramName)
        {
            this.paramType = paramType ?? throw new ArgumentNullException(nameof(paramType));
            this.paramName = paramName ?? throw new ArgumentNullException(nameof(paramName));
        }
    }
}
