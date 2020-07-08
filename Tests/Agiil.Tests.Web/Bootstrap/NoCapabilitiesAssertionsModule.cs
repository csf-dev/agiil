using System;
using Agiil.Domain.Capabilities;
using Autofac;
using Moq;
using Ref = System.Reflection;

namespace Agiil.Tests.Web.Bootstrap
{
    public class NoCapabilitiesAssertionsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(GetNoAssertionsProvider);
        }

        IGetsCapabilitiesAssertionsToPerform GetNoAssertionsProvider(IComponentContext ctx)
        {
            return Mock.Of<IGetsCapabilitiesAssertionsToPerform>(x => x.GetAssertionsToPerform(It.IsAny<Ref.MethodInfo>(), It.IsAny<object[]>()) == new CapabilitiesAssertionSpec[0]);
        }
    }
}
