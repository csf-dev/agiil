using System;
using Agiil.Domain.Activity;
using Agiil.Domain.Tickets;
using AutoMapper;

namespace Agiil.ObjectMaps.Resolvers
{
    public class TotalWorkLoggedForTicketResolver : IValueResolver<Ticket,object,TimeSpan>
    {
        readonly IGetsSumOfLoggedWorkForTicket workLogProvider;

        public TimeSpan Resolve(Ticket source, object destination, TimeSpan destMember, ResolutionContext context)
            => workLogProvider.GetTotalTimeLogged(source);

        public TotalWorkLoggedForTicketResolver(IGetsSumOfLoggedWorkForTicket workLogProvider)
        {
            this.workLogProvider = workLogProvider ?? throw new ArgumentNullException(nameof(workLogProvider));
        }
    }
}
