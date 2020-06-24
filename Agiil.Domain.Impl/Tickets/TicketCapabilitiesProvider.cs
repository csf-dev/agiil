using System;
using System.Linq;
using Agiil.Domain.Auth;
using Agiil.Domain.Capabilities;
using CSF.Entities;
using CSF.ORM;

namespace Agiil.Domain.Tickets
{
    public class TicketCapabilitiesProvider : IGetsUserCapabilities<Ticket, TicketCapability>
    {
        private readonly IEntityData data;

        public TicketCapability GetCapabilities(IIdentity<User> userIdentity, IIdentity<Ticket> targetEntity)
        {
            if(userIdentity == null)
                throw new ArgumentNullException(nameof(userIdentity));
            if(targetEntity == null) return default;

            var user = GetUser(userIdentity);
            var ticket = GetTicket(targetEntity);

            if(user == null || ticket == null)
                return default;

            var isTicketCreator = ticket.User == user;
            var isAContributor = user.ContributorTo.Contains(ticket.Project);
            var isAProjectAdmin = user.AdministratorOf.Contains(ticket.Project);
            var isASiteAdmin = user.SiteAdministrator;

            if(isASiteAdmin || isAProjectAdmin)
            {
                // IE: All of the capabilities!
                return Enum.GetValues(typeof(TicketCapability))
                    .Cast<TicketCapability>()
                    .Aggregate(default(TicketCapability), (acc, next) => acc | next);
            }

            if(isTicketCreator)
            {
                return TicketCapability.View
                     | TicketCapability.Edit
                     | TicketCapability.Delete
                     | TicketCapability.AddComment;
            }

            if(isAContributor)
            {
                return TicketCapability.View
                     | TicketCapability.AddComment;
            }

            return default;
        }

        User GetUser(IIdentity<User> identity)
        {
            var u = data.Theorise(identity);
            return data.Query<User>()
                .Where(x => x == u)
                .FetchChildren(x => x.ContributorTo)
                .FetchChildren(x => x.AdministratorOf)
                // Must use ToList first, because otherwise the fetches won't work
                .ToList()
                .FirstOrDefault();
        }

        Ticket GetTicket(IIdentity<Ticket> identity)
        {
            var t = data.Theorise(identity);
            return data.Query<Ticket>()
                .Where(x => x == t)
                .FetchChild(x => x.Project)
                .FetchChild(x => x.User)
                .FirstOrDefault();
        }

        public TicketCapabilitiesProvider(IEntityData data)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
