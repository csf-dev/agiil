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

      builder.Register(GetNewTicketModelFactory);
      builder.Register(GetEditTicketModelFactory);
		}

    IGetsNewTicketModel GetNewTicketModelFactory(IComponentContext ctx, IEnumerable<Parameter> afParams)
    {
      var factoryFactory = ctx.Resolve<IGetsNewTicketModelFactory>(afParams);
      return factoryFactory.GetNewTicketModelFactory();
    }

    IGetsEditTicketModel GetEditTicketModelFactory(IComponentContext ctx, IEnumerable<Parameter> afParams)
    {
      var factoryFactory = ctx.Resolve<IGetsEditTicketModelFactory>(afParams);
      return factoryFactory.GetEditTicketModelFactory();
    }
	}
}
