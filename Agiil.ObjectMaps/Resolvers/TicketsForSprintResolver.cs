using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.ObjectMaps.Resolvers
{
    public abstract class TicketsForSprintResolver : IValueResolver<Sprint, object, IReadOnlyCollection<TicketSummaryDto>>
    {
        readonly IGetsTicketsInSprint ticketProvider;
        readonly Func<IGetsTicketsInSprint, Sprint, IReadOnlyCollection<Ticket>> ticketFunction;

        public IReadOnlyCollection<TicketSummaryDto> Resolve(Sprint source,
                                                             object destination,
                                                             IReadOnlyCollection<TicketSummaryDto> destMember,
                                                             ResolutionContext context)
            => ticketFunction(ticketProvider, source).Select(context.Mapper.Map<TicketSummaryDto>).ToList();

        protected TicketsForSprintResolver(IGetsTicketsInSprint ticketProvider,
                                               Func<IGetsTicketsInSprint, Sprint, IReadOnlyCollection<Ticket>> ticketFunction)
        {
            this.ticketProvider = ticketProvider ?? throw new ArgumentNullException(nameof(ticketProvider));
            this.ticketFunction = ticketFunction ?? throw new ArgumentNullException(nameof(ticketFunction));
        }
    }

    public class OpenTicketsForSprintResolver : TicketsForSprintResolver
    {
        public OpenTicketsForSprintResolver(IGetsTicketsInSprint ticketProvider)
            : base(ticketProvider, (p, l) => p.GetAllOpenTickets(l)) { }
    }

    public class ClosedTicketsForSprintResolver : TicketsForSprintResolver
    {
        public ClosedTicketsForSprintResolver(IGetsTicketsInSprint ticketProvider)
            : base(ticketProvider, (p, l) => p.GetAllClosedTickets(l)) { }
    }
}
