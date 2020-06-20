using Agiil.Domain.Projects;
using Autofac;
using CSF.DecoratorBuilder;

namespace Agiil.Web.Bootstrap
{
    public class CurrentProjectModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterDecoratedService<IGetsCurrentProject>(x => x
                .UsingInitialImpl<FirstProjectInDatabaseProvider>()
                .ThenWrapWith<CurrentlyChosenProjectDecorator>());
        }
    }
}
