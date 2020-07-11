using Autofac;
using Agiil.Domain.Tickets.Editing;
using CSF.DecoratorBuilder;
using Agiil.Domain.Tickets;
using Autofac.Extras.DynamicProxy;
using Agiil.Bootstrap.Capabilities;

namespace Agiil.Bootstrap.Tickets
{
    public class TicketEditorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterDecoratedService<IEditsTicket>(b => b.UsingInitialImpl<AutomapperBasedTicketEditor>()
                    .ThenWrapWith<LabelResolvingTicketEditorDecorator>()
                    .ThenWrapWith<RelationshipAddingTicketEditorDecorator>()
                    .ThenWrapWith<RelationshipRemovingTicketEditorDecorator>())
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(CapabilitiesEnforcingInterceptor));
        }
    }
}
