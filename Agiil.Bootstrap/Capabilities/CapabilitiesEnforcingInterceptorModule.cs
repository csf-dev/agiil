using System;
using Agiil.Domain.Capabilities;
using Autofac;

namespace Agiil.Bootstrap.Capabilities
{
    public class CapabilitiesEnforcingInterceptorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CapabilitiesEnforcingInterceptor>()
                .AsSelf()
                .AsImplementedInterfaces();

            builder
                .RegisterType<NoAmbientAssertionDetector>()
                .SingleInstance();

            builder
                .RegisterType<AssertionInProgressDetector>()
                .InstancePerOwned<IAssertsUserHasCapability>();

            builder.Register(GetAmbientAssertionDetector);
        }

        IDetectsAmbientCapabilityAssertion GetAmbientAssertionDetector(IComponentContext ctx)
        {
            try
            {
                // Seems that there is no way to try resolving this (from its specialised
                // lifetime scope tag) without raising DependencyResolutionException if we
                // are not in a lifetime scope of that tag.
                return ctx.Resolve<AssertionInProgressDetector>();
            }
            catch(Autofac.Core.DependencyResolutionException)
            {
                return ctx.Resolve<NoAmbientAssertionDetector>();
            }
        }

        class NoAmbientAssertionDetector : IDetectsAmbientCapabilityAssertion
        {
            public bool IsCapabilityAssertionInProgress() => false;
        }

        class AssertionInProgressDetector : IDetectsAmbientCapabilityAssertion
        {
            public bool IsCapabilityAssertionInProgress() => true;
        }
    }
}
