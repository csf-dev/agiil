using System;
using Agiil.ObjectMaps;
using Agiil.Tests.Attributes;
using AutoFixture.NUnit3;
using NUnit.Framework;

namespace Agiil.Tests.ObjectMaps
{
    [TestFixture, Category("Integration"), Category("DependencyInjection")]
    public class AutoMapperValidityIntegrationTests
    {
        [Test, AutoData, WithDi, Description("AutoMapper exposes an internal mechanism in order to test its own mappings for basic validity.  See https://docs.automapper.org/en/stable/Getting-started.html#how-do-i-test-my-mappings")]
        public void AutoMapper_configuration_should_pass_its_own_internal_validity_test([FromDi] Lazy<IMapperConfigurationFactory> mapperConfigurationFactory)
        {
            var mapperConfig = mapperConfigurationFactory.Value.GetConfiguration();
            Assert.That(() => mapperConfig.AssertConfigurationIsValid(), Throws.Nothing);
        }
    }
}
