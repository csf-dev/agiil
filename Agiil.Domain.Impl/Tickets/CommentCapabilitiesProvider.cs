using System;
using System.Linq;
using Agiil.Domain.Auth;
using Agiil.Domain.Capabilities;
using CSF.Entities;
using CSF.ORM;

namespace Agiil.Domain.Tickets
{
    public class CommentCapabilitiesProvider : IGetsUserCapabilities<Comment, CommentCapability>
    {
        readonly IEntityData data;

        public CommentCapability GetCapabilities(IIdentity<User> userIdentity, IIdentity<Comment> targetEntity)
        {
            if(userIdentity == null)
                throw new ArgumentNullException(nameof(userIdentity));
            if(targetEntity == null) return 0;

            var user = GetUser(userIdentity);
            var comment = GetComment(targetEntity);

            if(user == null || comment == null)
                return 0;

            var isAuthor = user == comment.User;
            var isProjectAdmin = user.AdministratorOf.Contains(comment.Ticket.Project);
            var isASiteAdmin = user.SiteAdministrator;

            if(isAuthor || isProjectAdmin || isASiteAdmin)
            {
                // IE: All of the capabilities!
                return Enum.GetValues(typeof(CommentCapability))
                    .Cast<CommentCapability>()
                    .Aggregate(default(CommentCapability), (acc, next) => acc | next);

            }

            return 0;
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

        Comment GetComment(IIdentity<Comment> identity)
        {
            var t = data.Theorise(identity);
            return data.Query<Comment>()
                .Where(x => x == t)
                .FetchChild(x => x.Ticket)
                .ThenFetchGrandchild(x => x.Project)
                .FetchChild(x => x.User)
                .FirstOrDefault();
        }

        public CommentCapabilitiesProvider(IEntityData data)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
