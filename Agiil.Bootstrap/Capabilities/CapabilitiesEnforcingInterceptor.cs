using System;
using Agiil.Domain.Capabilities;
using Autofac.Features.OwnedInstances;
using Castle.DynamicProxy;

namespace Agiil.Bootstrap.Capabilities
{
    public class CapabilitiesEnforcingInterceptor : IInterceptor
    {
        readonly IGetsCapabilitiesAssertionsToPerform assertionSpecProvider;
        readonly Func<Owned<IAssertsUserHasCapability>> assertionExecutorFactory;
        readonly IDetectsAmbientCapabilityAssertion ambientAssertionDetector;

        public void Intercept(IInvocation invocation)
        {
            // We mustn't assert capabilities if there is already an assertion in progress.
            // Otherwise we risk a circular dependency/stack overflow.
            if(!ambientAssertionDetector.IsCapabilityAssertionInProgress())
                AssertCapabilities(invocation);

            invocation.Proceed();
        }

        void AssertCapabilities(IInvocation invocation)
        {
            var assertionsSpecs = assertionSpecProvider.GetAssertionsToPerform(invocation.Method,
                                                                               invocation.Arguments);
            foreach(var spec in assertionsSpecs)
            {
                using(var assertionExecutor = assertionExecutorFactory())
                    assertionExecutor.Value.AssertCurrentUserHasCapability(spec);
            }
        }

        public CapabilitiesEnforcingInterceptor(IGetsCapabilitiesAssertionsToPerform assertionSpecProvider,
                                                Func<Owned<IAssertsUserHasCapability>> assertionExecutorFactory,
                                                IDetectsAmbientCapabilityAssertion ambientAssertionDetector)
        {
            this.assertionSpecProvider = assertionSpecProvider ?? throw new ArgumentNullException(nameof(assertionSpecProvider));
            this.assertionExecutorFactory = assertionExecutorFactory ?? throw new ArgumentNullException(nameof(assertionExecutorFactory));
            this.ambientAssertionDetector = ambientAssertionDetector ?? throw new ArgumentNullException(nameof(ambientAssertionDetector));
        }
    }
}
