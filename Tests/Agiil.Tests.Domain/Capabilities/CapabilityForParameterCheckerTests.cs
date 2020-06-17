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
    public class CapabilityForParameterCheckerTests
    {
        [Test, AutoMoqData]
        public void AssertCurrentUserHasCapability_throws_exception_if_spec_is_null(CapabilityForParameterChecker sut)
        {
            Assert.That(() => sut.AssertCurrentUserHasCapability(null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test, AutoMoqData]
        public void AssertCurrentUserHasCapability_throws_ArgumentException_if_capability_type_is_not_enum(string paramName,
                                                                                                           string actionName,
                                                                                                           Type paramType,
                                                                                                           object paramValue,
                                                                                                           int incorrectCapabilityValue,
                                                                                                           CapabilityForParameterChecker sut)
        {
            var spec = new CapabilitiesAssertionSpec(paramName, paramType, paramValue, new RequireCapabilityAttribute(incorrectCapabilityValue), actionName);
            Assert.That(() => sut.AssertCurrentUserHasCapability(spec),
                        Throws.InstanceOf<ArgumentException>().And.Message.Matches<string>(x => x.Contains("must derive from Enum")));
        }

        [Test, AutoMoqData]
        public void AssertCurrentUserHasCapability_invokes_tester_with_correct_parameters([Frozen] IGetsTypedCapabilityTester testerFactory,
                                                                                          [Frozen] IGetsEntityTypeForCapability entityTypeProvider,
                                                                                          [Frozen] IGetsCurrentCapabilityUser userProvider,
                                                                                          [Frozen] IGetsTargetEntityIdentity targetEntityProvider,
                                                                                          IAssertsUserHasCapability<SampleEntity,CapabilitySpecAttribute.SampleCapability> tester,
                                                                                          [CapabilitySpec] CapabilitiesAssertionSpec spec,
                                                                                          IIdentity<SampleEntity> entity,
                                                                                          IIdentity<User> user,
                                                                                          CapabilityForParameterChecker sut)
        {
            Mock.Get(entityTypeProvider)
                .Setup(x => x.GetEntityType(spec.CapabilityAttribute.RequiredCapability))
                .Returns(typeof(SampleEntity));
            Mock.Get(targetEntityProvider)
                .Setup(x => x.GetTargetEntityIdentity<SampleEntity>(spec.ParameterValue))
                .Returns(entity);
            Mock.Get(testerFactory)
                .Setup(x => x.GetCapabilityTester<SampleEntity, CapabilitySpecAttribute.SampleCapability>())
                .Returns(tester);
            Mock.Get(userProvider)
                .Setup(x => x.GetCurrentCapabilityUser())
                .Returns(user);
            var expectedCapability = (CapabilitySpecAttribute.SampleCapability) spec.CapabilityAttribute.RequiredCapability;

            sut.AssertCurrentUserHasCapability(spec);

            Mock.Get(tester)
                .Verify(x => x.AssertUserHasCapability(user, entity, expectedCapability), Times.Once);
        }

        [Test, AutoMoqData]
        public void AssertCurrentUserHasCapability_does_not_invoke_tester_if_spec_param_value_does_not_return_entity([Frozen] IGetsTypedCapabilityTester testerFactory, 
                                                                                                                     [Frozen] IGetsEntityTypeForCapability entityTypeProvider,
                                                                                                                     [Frozen] IGetsTargetEntityIdentity targetEntityProvider,
                                                                                                                     [CapabilitySpec] CapabilitiesAssertionSpec spec,
                                                                                                                     CapabilityForParameterChecker sut)
        {
            Mock.Get(entityTypeProvider)
                .Setup(x => x.GetEntityType(spec.CapabilityAttribute.RequiredCapability))
                .Returns(typeof(SampleEntity));
            Mock.Get(targetEntityProvider)
                .Setup(x => x.GetTargetEntityIdentity<SampleEntity>(spec.ParameterValue))
                .Returns(() => null);

            sut.AssertCurrentUserHasCapability(spec);

            Mock.Get(testerFactory)
                .Verify(x => x.GetCapabilityTester<SampleEntity, CapabilitySpecAttribute.SampleCapability>(), Times.Never);
        }

        #region contained types

        public class SampleEntity : Entity<long> { }

        #endregion
    }
}
