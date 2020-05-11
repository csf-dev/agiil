using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Domain.Labels;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.ObjectMaps.Resolvers
{
    public abstract class TicketsForLabelResolver : IValueResolver<Label, object, IReadOnlyCollection<TicketSummaryDto>>
    {
        readonly IGetsTicketsWithLabel ticketProvider;
        readonly Func<IGetsTicketsWithLabel, Label, IReadOnlyCollection<Ticket>> ticketFunction;

        public IReadOnlyCollection<TicketSummaryDto> Resolve(Label source,
                                                             object destination,
                                                             IReadOnlyCollection<TicketSummaryDto> destMember,
                                                             ResolutionContext context)
            => ticketFunction(ticketProvider, source).Select(context.Mapper.Map<TicketSummaryDto>).ToList();

        protected TicketsForLabelResolver(IGetsTicketsWithLabel ticketProvider,
                                               Func<IGetsTicketsWithLabel, Label, IReadOnlyCollection<Ticket>> ticketFunction)
        {
            this.ticketProvider = ticketProvider ?? throw new ArgumentNullException(nameof(ticketProvider));
            this.ticketFunction = ticketFunction ?? throw new ArgumentNullException(nameof(ticketFunction));
        }
    }

    public class OpenTicketsForLabelResolver : TicketsForLabelResolver
    {
        public OpenTicketsForLabelResolver(IGetsTicketsWithLabel ticketProvider)
            : base(ticketProvider, (p, l) => p.GetAllOpenTickets(l)) { }
    }

    public class ClosedTicketsForLabelResolver : TicketsForLabelResolver
    {
        public ClosedTicketsForLabelResolver(IGetsTicketsWithLabel ticketProvider)
            : base(ticketProvider, (p, l) => p.GetAllClosedTickets(l)) { }
    }
}
