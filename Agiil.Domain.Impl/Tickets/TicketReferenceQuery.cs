using System;
using System.Linq;
using CSF.Data.Entities;

namespace Agiil.Domain.Tickets
{
  public class TicketReferenceQuery : ITicketReferenceQuery
  {
    readonly ITicketReferenceParser parser;
    readonly IEntityData repo;

    public Ticket GetTicketByReference(string reference)
    {
      var parsed = parser.ParseReferece(reference);

      if(parsed == null)
        return null;

      return repo
        .Query<Ticket>()
        .Where(x => x.Project != null
                    && x.Project.Code == parsed.ProjectCode
                    && x.TicketNumber == parsed.TicketNumber)
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
