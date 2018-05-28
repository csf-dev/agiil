using System;
using System.Linq;
using CSF.Data.Entities;
using CSF.Data.Specifications;

namespace Agiil.Domain.Tickets
{
  public class TicketReferenceQuery : ITicketReferenceQuery
  {
    readonly ITicketReferenceParser parser;
    readonly IEntityData repo;

    public Ticket GetTicketByReference(string reference)
    {
      var parsed = parser.ParseReferece(reference);
      return GetTicketByReference(parsed);
    }

    public Ticket GetTicketByReference(TicketReference reference)
    {
      if(reference == null) return null;

      var spec = new TicketReferenceSpecification(reference);

      return repo
        .Query<Ticket>()
        .Where(spec)
        .SingleOrDefault();
    }

    public TicketReferenceQuery(ITicketReferenceParser parser,
                                IEntityData repo)
    {
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      if(parser == null)
        throw new ArgumentNullException(nameof(parser));

      this.repo = repo;
      this.parser = parser;
    }
  }
}
