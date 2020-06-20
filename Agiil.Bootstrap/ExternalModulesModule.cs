using System;
using Autofac;

namespace Agiil.Bootstrap
{
    public class ExternalModulesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CSF.DecoratorBuilder.DecoratorBuilderModule>();
        }
    }
}
