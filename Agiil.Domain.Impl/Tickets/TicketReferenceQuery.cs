using System;
using System.Linq;
using Agiil.Domain.Tickets.Specs;
using CSF.ORM;
using CSF.Specifications;

namespace Agiil.Domain.Tickets
{
    public class TicketReferenceQuery : IGetsTicketByReference
    {
        readonly IEntityData repo;
        readonly Func<TicketReference, ISpecForTicketReferenceEquality> specFactory;

        public Ticket GetTicketByReference(TicketReference reference)
        {
            if(reference == null) return null;

            var spec = specFactory(reference);

            return repo
              .Query<Ticket>()
              .Where(spec)
              .SingleOrDefault();
        }

        public TicketReferenceQuery(IEntityData repo,
                                    Func<TicketReference, ISpecForTicketReferenceEquality> specFactory)
        {
            this.repo = repo ?? throw new ArgumentNullException(nameof(repo));
            this.specFactory = specFactory ?? throw new ArgumentNullException(nameof(specFactory));
        }
    }
}
