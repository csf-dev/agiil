using System;
using System.Reflection;
using Agiil.Domain.Capabilities;
using Agiil.Tests.Attributes;
using CSF.Reflection;
using NUnit.Framework;

namespace Agiil.Tests.Capabilities
{
    [TestFixture,Parallelizable]
    public class CapabilityAssertionSpecProviderTests
    {
        [Test, AutoMoqData]
        public void GetAssertionsToPerform_throws_exception_if_method_is_null(CapabilityAssertionSpecProvider sut)
        {
            Assert.That(() => sut.GetAssertionsToPerform(null, new object[0]), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test, AutoMoqData]
        public void GetAssertionsToPerform_throws_exception_if_parameters_are_null(CapabilityAssertionSpecProvider sut)
        {
            Assert.That(() => sut.GetAssertionsToPerform(MethodWith1RequiredCapability, null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test, AutoMoqData]
        public void GetAssertionsToPerform_throws_exception_if_parameter_count_does_not_match_method_param_count(CapabilityAssertionSpecProvider sut)
        {
            Assert.That(() => sut.GetAssertionsToPerform(MethodWith1RequiredCapability, new object[] { null, null }), Throws.InstanceOf<ArgumentException>());
        }

        [Test, AutoMoqData]
        public void GetAssertionsToPerform_does_not_throw_if_parameter_count_matches_method_param_count(CapabilityAssertionSpecProvider sut)
        {
            Assert.That(() => sut.GetAssertionsToPerform(MethodWith1RequiredCapability, new object[] { null }), Throws.Nothing);
        }

        [Test, AutoMoqData]
        public void GetAssertionsToPerform_returns_correct_spec_for_one_capability(CapabilityAssertionSpecProvider sut, string fooVal)
        {
            var result = sut.GetAssertionsToPerform(MethodWith1RequiredCapability, new object[] { fooVal });
            Assert.That(result,
                        Has.Exactly(1).Matches<CapabilitiesAssertionSpec>(x => Equals(x.CapabilityAttribute.RequiredCapability, SampleCapability.One)
                                                                               && x.ParameterName == "foo"
                                                                               && Equals(x.ParameterValue, fooVal)));
        }

        [Test, AutoMoqData]
        public void GetAssertionsToPerform_returns_correct_specs_for_two_capabilities(CapabilityAssertionSpecProvider sut,
                                                                                      string fooVal,
                                                                                      int barVal,
                                                                                      int bazVal)
        {
            var result = sut.GetAssertionsToPerform(MethodWith2RequiredCapabilities, new object[] { fooVal, barVal, bazVal });
            Assert.That(result,
                        Has.Exactly(1).Matches<CapabilitiesAssertionSpec>(x => Equals(x.CapabilityAttribute.RequiredCapability, SampleCapability.Three)
                                                                               && x.ParameterName == "foo"
                                                                               && Equals(x.ParameterValue, fooVal)),
                        "A spec is returned for parameter 'foo' with correct values");
            Assert.That(result,
                        Has.Exactly(1).Matches<CapabilitiesAssertionSpec>(x => Equals(x.CapabilityAttribute.RequiredCapability, SampleCapability.Two)
                                                                               && x.ParameterName == "baz"
                                                                               && Equals(x.ParameterValue, bazVal)),
                        "A spec is returned for parameter 'baz' with correct values");
            Assert.That(result,
                        Has.None.Matches<CapabilitiesAssertionSpec>(x => x.ParameterName == "bar"),
                        "A spec is not returned for parameter 'bar' because it is not decorated with the attribute");
        }

        MethodInfo MethodWith1RequiredCapability => Reflect.Method<ISampleInterface>(x => x.MethodWith1RequiredCapability(null));
        MethodInfo MethodWith2RequiredCapabilities => Reflect.Method<ISampleInterface>(x => x.MethodWith2RequiredCapabilities(null, 0, 0));

        #region contained_types

        enum SampleCapability
        {
            One,
            Two,
            Three
        }

        interface ISampleInterface
        {
            void MethodWith1RequiredCapability([RequireCapability(SampleCapability.One)] string foo);

            void MethodWith2RequiredCapabilities([RequireCapability(SampleCapability.Three)] string foo,
                                                 int bar,
                                                 [RequireCapability(SampleCapability.Two)] int baz);
        }

        #endregion
    }
}
