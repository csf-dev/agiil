using System;
using Autofac;
using CSF.Configuration;

namespace Agiil.Bootstrap
{
    public class ExternalModulesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CSF.DecoratorBuilder.DecoratorBuilderModule>();

            builder.RegisterAssemblyTypes(typeof(IConfigurationReader).Assembly)
                .AsSelf()
                .AsImplementedInterfaces();
        }
    }
}
