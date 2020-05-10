using System;
using Agiil.Domain.Tickets;
using Autofac;

namespace Agiil.Tests.Bootstrap
{
    public class TicketUriProviderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FakeTicketUriProvider>().AsImplementedInterfaces();
        }

        class FakeTicketUriProvider : IGetsTicketUris
        {
            public Uri GetEditTicketUri(TicketReference reference)
            {
                return new Uri($"EditTicket/{reference}");
            }

            public Uri GetViewTicketUri(TicketReference reference)
            {
                return new Uri($"ViewTicket/{reference}");
            }
        }
    }
}
