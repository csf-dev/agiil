using System;
using Agiil.Domain.Capabilities;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using CSF.Entities;

namespace Agiil.Web.Services.Tickets
{
    public class UserCanEditTicketDetailDecorator : IGetsTicketDetailDtoByReference
    {
        readonly IGetsTicketDetailDtoByReference wrapped;
        readonly IDeterminesIfCurrentUserHasCapability capabilityProvider;

        public TicketDetailDto GetTicketDetailDto(TicketReference reference)
        {
            var result = wrapped.GetTicketDetailDto(reference);
            if(result == null) return null;

            result.CanEdit = capabilityProvider.DoesUserHaveCapability(TicketCapability.Edit, Identity.Create<Ticket>(result.Id));
            return result;
        }

        public UserCanEditTicketDetailDecorator(IGetsTicketDetailDtoByReference wrapped,
                                                IDeterminesIfCurrentUserHasCapability capabilityProvider)
        {
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
            this.capabilityProvider = capabilityProvider ?? throw new ArgumentNullException(nameof(capabilityProvider));
        }
    }
}
