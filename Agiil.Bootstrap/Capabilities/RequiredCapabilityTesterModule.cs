using System;
using Agiil.Domain.Capabilities;
using Autofac;

namespace Agiil.Bootstrap.Capabilities
{
    public class RequiredCapabilityTesterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(RequiredCapabilityTester<,>))
                .AsSelf()
                .As(typeof(IAssertsUserHasCapability<,>));
        }
    }
}
