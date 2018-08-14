using Autofac;
using Agiil.Domain.Tickets.Editing;

namespace Agiil.Bootstrap.Tickets
{
  public class TicketEditorModule : Module
  {
		protected override void Load(ContainerBuilder builder)
		{
      builder.Register(ctx => ctx.Resolve<IGetsTicketEditor>().GetTicketEditor());
		}
  }
}
