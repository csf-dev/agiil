using System;
using Agiil.Domain.Capabilities;
using Agiil.Tests.Attributes;
using NUnit.Framework;

namespace Agiil.Tests.Capabilities
{
    [TestFixture,Parallelizable]
    public class CapabilityEnforcementProviderTests
    {
        [Test, AutoMoqData]
        public void ShouldCapabilitiesBeEnforced_returns_false_if_the_type_is_null(CapabilityEnforcementProvider sut)
        {
            Assert.That(() => sut.ShouldCapabilitiesBeEnforced(null), Is.False);
        }

        [Test, AutoMoqData]
        public void ShouldCapabilitiesBeEnforced_returns_false_if_the_type_is_not_an_interface(CapabilityEnforcementProvider sut)
        {
            Assert.That(() => sut.ShouldCapabilitiesBeEnforced(typeof(string)), Is.False);
        }

        [Test, AutoMoqData]
        public void ShouldCapabilitiesBeEnforced_returns_false_if_the_interface_is_not_decorated_with_EnforceCapabilities(CapabilityEnforcementProvider sut)
        {
            Assert.That(() => sut.ShouldCapabilitiesBeEnforced(typeof(ISampleInterfaceWithoutEnforcement)), Is.False);
        }

        [Test, AutoMoqData]
        public void ShouldCapabilitiesBeEnforced_returns_true_if_the_interface_is_decorated_with_EnforceCapabilities(CapabilityEnforcementProvider sut)
        {
            Assert.That(() => sut.ShouldCapabilitiesBeEnforced(typeof(ISampleInterface)), Is.True);
        }

        #region contained types

        [EnforceCapabilities]
        public interface ISampleInterface { }

        public interface ISampleInterfaceWithoutEnforcement { }

        #endregion
    }
}
