using System;
using Agiil.Domain.Tickets;
using Autofac;

namespace Agiil.Bootstrap.Tickets
{
  public class TickatReferenceParserModule : Module
  {
		protected override void Load(ContainerBuilder builder)
		{
      builder
        .Register(ctx => {
          var baseParser = (IParsesTicketReference) ctx.Resolve<TicketReferenceParser>();
          return ctx.Resolve<CurrentProjectBackfillingTicketReferenceParserDecorator>(TypedParameter.From(baseParser));
        })
        .As<IParsesTicketReference>();
		}
	}
}
