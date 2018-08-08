using System;
using System.Collections.Generic;
using System.Web.Mvc;
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
      builder.RegisterType<AvailableRelationshipsEditTicketModelFactoryDecorator>();
      builder.RegisterType<AvailableSprintsEditTicketModelFactoryDecorator>();
      builder.RegisterType<AvailableTicketTypesEditTicketModelFactoryDecorator>();
      builder.RegisterType<EditTicketModelFactoryFactory>();
      builder.RegisterType<MappingEditTicketModelFactory>();
      builder.RegisterType<TempDataRestoringEditTicketModelFactoryDecorator>();

      builder.Register(GetEditTicketModelFactory);
      builder.Register(GetEditTicketModelFactoryFactory);
		}

    IGetsEditTicketModel GetEditTicketModelFactory(IComponentContext ctx, IEnumerable<Parameter> afParams)
    {
      var factoryFactory = ctx.Resolve<IGetsEditTicketModelFactory>(afParams);
      return factoryFactory.GetEditTicketModelFactory();
    }

    IGetsEditTicketModelFactory GetEditTicketModelFactoryFactory(IComponentContext ctx, IEnumerable<Parameter> afParams)
    {
      var tempDataProvider = ctx.Resolve<IGetsTempData>(afParams);
      var tempDataParam = new TypedParameter(typeof(IGetsTempData), tempDataProvider);
      return ctx.Resolve<EditTicketModelFactoryFactory>(tempDataParam);
    }
	}
}
