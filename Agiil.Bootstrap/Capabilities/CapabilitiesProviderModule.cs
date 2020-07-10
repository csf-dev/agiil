using System;
using Agiil.Domain.Auth;
using Agiil.Domain.Capabilities;
using Autofac;
using CSF.Entities;

namespace Agiil.Bootstrap.Capabilities
{
    public class CapabilitiesProviderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NonGenericCapabilitiesProviderAdapter>().AsSelf().AsImplementedInterfaces();
        }

        class NonGenericCapabilitiesProviderAdapter : IGetsUserCapabilities
        {
            readonly ILifetimeScope scope;

            TCapability IGetsUserCapabilities.GetCapabilities<TEntity, TCapability>(IIdentity<User> userIdentity,
                                                                                    IIdentity<TEntity> targetEntity)
            {
                var typedTester = scope.Resolve<IGetsUserCapabilities<TEntity, TCapability>>();
                return typedTester.GetCapabilities(userIdentity, targetEntity);
            }

            public NonGenericCapabilitiesProviderAdapter(ILifetimeScope scope)
            {
                this.scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }
        }
    }
}
