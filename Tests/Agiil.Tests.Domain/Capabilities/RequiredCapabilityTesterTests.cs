using System;
using Agiil.Domain.Auth;
using Agiil.Domain.Capabilities;
using Agiil.Tests.Attributes;
using AutoFixture.NUnit3;
using CSF.Entities;
using Moq;
using NUnit.Framework;

namespace Agiil.Tests.Capabilities
{
    [TestFixture,Parallelizable]
    public class RequiredCapabilityTesterTests
    {
        [Test, AutoMoqData]
        public void AssertUserHasCapability_throws_if_capability_is_not_a_flags_enum(RequiredCapabilityTester<SampleEntity, NotAFlagsEnum> sut,
                                                                                     IIdentity<User> userId,
                                                                                     IIdentity<SampleEntity> entityId,
                                                                                     NotAFlagsEnum cap)
        {
            Assert.That(() => sut.AssertUserHasCapability(userId, entityId, cap), Throws.Exception);
        }

        [Test, AutoMoqData]
        public void AssertUserHasCapability_throws_UserMustHaveCapabilityException_if_user_does_not_have_single_required_capability([Frozen] IGetsUserCapabilities<SampleEntity, SampleEntityCapability> capabilitiesProvider,
                                                                                                                                    RequiredCapabilityTester<SampleEntity, SampleEntityCapability> sut,
                                                                                                                                    IIdentity<User> userId,
                                                                                                                                    IIdentity<SampleEntity> entityId)
        {
            Mock.Get(capabilitiesProvider)
                .Setup(x => x.GetCapabilities(userId, entityId))
                .Returns(SampleEntityCapability.Two);

            Assert.That(() => sut.AssertUserHasCapability(userId, entityId, SampleEntityCapability.One),
                        Throws.InstanceOf<UserMustHaveCapabilityException>());
        }

        [Test, AutoMoqData]
        public void AssertUserHasCapability_throws_nothing_if_user_has_single_required_capability([Frozen] IGetsUserCapabilities<SampleEntity, SampleEntityCapability> capabilitiesProvider,
                                                                                                  RequiredCapabilityTester<SampleEntity, SampleEntityCapability> sut,
                                                                                                  IIdentity<User> userId,
                                                                                                  IIdentity<SampleEntity> entityId)
        {
            Mock.Get(capabilitiesProvider)
                .Setup(x => x.GetCapabilities(userId, entityId))
                .Returns(SampleEntityCapability.Two);

            Assert.That(() => sut.AssertUserHasCapability(userId, entityId, SampleEntityCapability.Two),
                        Throws.Nothing);
        }

        [Test, AutoMoqData]
        public void AssertUserHasCapability_throws_UserMustHaveCapabilityException_if_user_does_not_have_all_required_capabilities([Frozen] IGetsUserCapabilities<SampleEntity, SampleEntityCapability> capabilitiesProvider,
                                                                                                                                   RequiredCapabilityTester<SampleEntity, SampleEntityCapability> sut,
                                                                                                                                   IIdentity<User> userId,
                                                                                                                                   IIdentity<SampleEntity> entityId)
        {
            Mock.Get(capabilitiesProvider)
                .Setup(x => x.GetCapabilities(userId, entityId))
                .Returns(SampleEntityCapability.Two);

            Assert.That(() => sut.AssertUserHasCapability(userId, entityId, SampleEntityCapability.One | SampleEntityCapability.Two),
                        Throws.InstanceOf<UserMustHaveCapabilityException>());
        }

        [Test, AutoMoqData]
        public void AssertUserHasCapability_throws_nothing_if_user_has_all_required_capabilities([Frozen] IGetsUserCapabilities<SampleEntity, SampleEntityCapability> capabilitiesProvider,
                                                                                                  RequiredCapabilityTester<SampleEntity, SampleEntityCapability> sut,
                                                                                                  IIdentity<User> userId,
                                                                                                  IIdentity<SampleEntity> entityId)
        {
            Mock.Get(capabilitiesProvider)
                .Setup(x => x.GetCapabilities(userId, entityId))
                .Returns(SampleEntityCapability.Two | SampleEntityCapability.One);

            Assert.That(() => sut.AssertUserHasCapability(userId, entityId, SampleEntityCapability.Two | SampleEntityCapability.One),
                        Throws.Nothing);
        }

        #region contained types

        public class SampleEntity : Entity<long> { }

        public enum NotAFlagsEnum
        {
            AValue,
        }

        [Flags]
        public enum SampleEntityCapability
        {
            One = 1 << 0,
            Two = 1 << 1,
            Three = 1 << 2,
        }

        #endregion
    }
}
