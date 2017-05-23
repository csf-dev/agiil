using System;
using Agiil.Web.Services.Tickets;
using Autofac;

namespace Agiil.Web.Bootstrap
{
  public class TicketsServicesModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<TicketSummaryMapper>();
      builder.RegisterType<TicketDetailMapper>();
      builder.RegisterType<CommentMapper>();
    }
  }
}
