using System;
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
        }
    }
}
