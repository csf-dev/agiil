using System;
using System.Linq;
using Agiil.Domain.Tickets.Specs;
using CSF.Data.Entities;
using CSF.Data.Specifications;

namespace Agiil.Domain.Tickets
{
  public class TicketReferenceQuery : IGetsTicketByReference
  {
    readonly IParsesTicketReference parser;
    readonly IEntityData repo;
    readonly Func<TicketReference, TicketReferenceEquals> specFactory;

    public Ticket GetTicketByReference(string reference)
    {
      var parsed = parser.ParseReferece(reference);
      return GetTicketByReference(parsed);
    }

    public Ticket GetTicketByReference(TicketReference reference)
    {
      if(reference == null) return null;

      var spec = specFactory(reference);

      return repo
        .Query<Ticket>()
        .Where(spec)
        .SingleOrDefault();
    }

    public TicketReferenceQuery(IParsesTicketReference parser,
                                IEntityData repo,
                                Func<TicketReference,TicketReferenceEquals> specFactory)
    {
      if(specFactory == null)
        throw new ArgumentNullException(nameof(specFactory));
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      if(parser == null)
        throw new ArgumentNullException(nameof(parser));

      this.repo = repo;
      this.specFactory = specFactory;
      this.parser = parser;
    }
  }
}
