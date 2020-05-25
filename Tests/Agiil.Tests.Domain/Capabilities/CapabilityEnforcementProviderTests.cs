using System;
using Agiil.Domain.Capabilities;
using Agiil.Tests.Attributes;
using CSF.Specifications;
using NUnit.Framework;

namespace Agiil.Tests.Capabilities
{
    [TestFixture,Parallelizable]
    public class CapabilityEnforcementProviderTests
    {
        [Test, AutoMoqData]
        public void Matches_returns_false_if_the_type_is_null(CapabilityEnforcementSpec sut)
        {
            Assert.That(() => sut.Matches(null), Is.False);
        }

        [Test, AutoMoqData]
        public void Matches_returns_false_if_the_type_is_not_an_interface(CapabilityEnforcementSpec sut)
        {
            Assert.That(() => sut.Matches(typeof(string)), Is.False);
        }

        [Test, AutoMoqData]
        public void Matches_returns_false_if_the_interface_is_not_decorated_with_EnforceCapabilities(CapabilityEnforcementSpec sut)
        {
            Assert.That(() => sut.Matches(typeof(ISampleInterfaceWithoutEnforcement)), Is.False);
        }

        [Test, AutoMoqData]
        public void Matches_returns_true_if_the_interface_is_decorated_with_EnforceCapabilities(CapabilityEnforcementSpec sut)
        {
            Assert.That(() => sut.Matches(typeof(ISampleInterface)), Is.True);
        }

        #region contained types

        [EnforceCapabilities]
        public interface ISampleInterface { }

        public interface ISampleInterfaceWithoutEnforcement { }

        #endregion
    }
}
