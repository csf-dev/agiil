using Autofac;
using Agiil.Domain.Tickets.Creation;
using CSF.DecoratorBuilder;
using Agiil.Domain.Tickets;
using Agiil.Bootstrap.Capabilities;
using Autofac.Extras.DynamicProxy;

namespace Agiil.Bootstrap.Tickets
{
    public class TicketCreatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterDecoratedService<ICreatesTicket>(d => d.UsingInitialImpl<TicketFactory>()
                    .ThenWrapWith<TicketTypePopulatingTicketFactoryDecorator>()
                    .ThenWrapWith<CurrentProjectSettingTicketFactoryDecorator>()
                    .ThenWrapWith<CurrentUserSettingTicketFactoryDecorator>()
                    .ThenWrapWith<LabelPopulatingTicketFactoryDecorator>()
                    .ThenWrapWith<SprintPopulatingTicketFactoryDecorator>()
                    .ThenWrapWith<RelationshipPopulatingTicketFactoryDecorator>()
                    // This one is intentionally last, so that everything above happens within a transaction
                    .ThenWrapWith<PersistingTicketFactoryDecorator>())
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(CapabilitiesEnforcingInterceptor));
        }
    }
}
