using System;
using Agiil.Domain.Capabilities;
using Castle.DynamicProxy;

namespace Agiil.Bootstrap.Capabilities
{
    public class CapabilitiesEnforcingInterceptor : IInterceptor
    {
        readonly IGetsCapabilitiesAssertionsToPerform assertionSpecProvider;
        readonly IAssertsUserHasCapability assertionExecutor;

        public void Intercept(IInvocation invocation)
        {
            var assertionsSpecs = assertionSpecProvider.GetAssertionsToPerform(invocation.Method,
                                                                               invocation.Arguments);
            foreach(var spec in assertionsSpecs)
                assertionExecutor.AssertCurrentUserHasCapability(spec);
        }

        public CapabilitiesEnforcingInterceptor(IGetsCapabilitiesAssertionsToPerform assertionSpecProvider,
                                                IAssertsUserHasCapability assertionExecutor)
        {
            this.assertionSpecProvider = assertionSpecProvider ?? throw new ArgumentNullException(nameof(assertionSpecProvider));
            this.assertionExecutor = assertionExecutor ?? throw new ArgumentNullException(nameof(assertionExecutor));
        }
    }
}
