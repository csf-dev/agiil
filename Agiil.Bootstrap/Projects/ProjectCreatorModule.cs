using System;
using Agiil.Bootstrap.Capabilities;
using Agiil.Domain.Projects;
using Autofac;
using Autofac.Extras.DynamicProxy;
using CSF.DecoratorBuilder;

namespace Agiil.Bootstrap.Projects
{
    public class ProjectCreatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterDecoratedService<ICreatesProject>(x =>
                    x.UsingInitialImpl<ProjectCreator>()
                     .ThenWrapWith<ValidatingProjectCreatorDecorator>()
                     .ThenWrapWith<TransactionProjectCreatorDecorator>()
                )
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(CapabilitiesEnforcingInterceptor));
        }
    }
}
