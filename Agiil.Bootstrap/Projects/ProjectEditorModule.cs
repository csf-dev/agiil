using System;
using Agiil.Bootstrap.Capabilities;
using Agiil.Domain.Projects;
using Autofac;
using Autofac.Extras.DynamicProxy;
using CSF.DecoratorBuilder;

namespace Agiil.Bootstrap.Projects
{
    public class ProjectEditorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterDecoratedService<IEditsProject>(x =>
                    x.UsingInitialImpl<ProjectEditor>()
                     .ThenWrapWith<ValidatingProjectEditorDecorator>()
                     .ThenWrapWith<TransactionProjectEditorDecorator>()
                )
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(CapabilitiesEnforcingInterceptor));
        }
    }
}
