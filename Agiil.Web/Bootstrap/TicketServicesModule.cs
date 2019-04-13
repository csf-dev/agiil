using System;
using System.Collections.Generic;
using Agiil.Web.Services;
using Agiil.Web.Services.Tickets;
using Autofac;
using Autofac.Core;

namespace Agiil.Web.Bootstrap
{
  public class TicketServicesModule : Module
  {
		protected override void Load(ContainerBuilder builder)
		{
      builder.RegisterType<AvailableRelationshipsTicketModelFactoryDecorator>();
      builder.RegisterType<AvailableSprintsTicketModelFactoryDecorator>();
      builder.RegisterType<AvailableTicketTypesTicketModelFactoryDecorator>();
      builder.RegisterType<AvailableRelationshipsNewTicketModelFactoryDecorator>();
      builder.RegisterType<AvailableSprintsNewTicketModelFactoryDecorator>();
      builder.RegisterType<AvailableTicketTypesNewTicketModelFactoryDecorator>();
      builder.RegisterType<EditTicketModelFactoryFactory>().AsImplementedInterfaces();
      builder.RegisterType<NewTicketModelFactoryFactory>().AsImplementedInterfaces();
      builder.RegisterType<MappingEditTicketModelFactory>();
      builder.RegisterType<SpecificationBasedNewTicketModelFactory>();
      builder.RegisterType<TempDataRestoringEditTicketModelFactoryDecorator>();
      builder.RegisterType<TicketDetailDtoProvider>().AsSelf().AsImplementedInterfaces();

      builder.Register(GetNewTicketModelFactory);
      builder.Register(GetEditTicketModelFactory);
		}

    IGetsNewTicketModel GetNewTicketModelFactory(IComponentContext ctx)
      => ctx.Resolve<IGetsNewTicketModelFactory>().GetNewTicketModelFactory();

    IGetsEditTicketModel GetEditTicketModelFactory(IComponentContext ctx)
      => ctx.Resolve<IGetsEditTicketModelFactory>().GetEditTicketModelFactory();
	}
}
