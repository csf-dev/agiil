using Autofac;
using Agiil.Domain.Tickets.Creation;

namespace Agiil.Bootstrap.Tickets
{
  public class TicketFactoryModule : Autofac.Module
  {
		protected override void Load(ContainerBuilder builder)
		{
      builder.Register(ctx => ctx.Resolve<IGetsTicketCreator>().GetTicketCreator());
		}
	}
}
