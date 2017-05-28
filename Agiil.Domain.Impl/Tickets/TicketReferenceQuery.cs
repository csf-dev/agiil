using System;
using System.Linq;
using CSF.Data.Entities;

namespace Agiil.Domain.Tickets
{
  public class TicketReferenceQuery : ITicketReferenceQuery
  {
    readonly ITicketReferenceParser parser;
    readonly IRepository<Ticket> repo;

    public Ticket GetTicketByReference(string reference)
    {
      var parsed = parser.ParseReferece(reference);

      if(parsed == null)
        return null;

      return repo
        .Query()
        .Where(x => x.Project != null
                    && x.Project.Code == parsed.ProjectCode
                    && x.TicketNumber == parsed.TicketNumber)
        .SingleOrDefault();
    }

    public TicketReferenceQuery(ITicketReferenceParser parser,
                                IRepository<Ticket> repo)
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
