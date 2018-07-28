using System;
using System.Linq;
using Agiil.Domain.Projects;
using Agiil.Domain.Tickets.Specs;
using CSF.Data.Entities;
using CSF.Data.Specifications;

namespace Agiil.Domain.Tickets
{
  public class TicketReferenceQuery : ITicketReferenceQuery
  {
    readonly ITicketReferenceParser parser;
    readonly IEntityData repo;
    readonly ICurrentProjectGetter currentProjectProvider;

    public Ticket GetTicketByReference(string reference)
    {
      var parsed = parser.ParseReferece(reference);
      return GetTicketByReference(parsed);
    }

    public Ticket GetTicketByReference(TicketReference reference)
    {
      if(reference == null) return null;

      var refWithProjectCode = GetReferenceWithProjectCode(reference);
      var spec = new TicketReferenceEquals(refWithProjectCode);

      return repo
        .Query<Ticket>()
        .Where(spec)
        .SingleOrDefault();
    }

    TicketReference GetReferenceWithProjectCode(TicketReference reference)
    {
      if(!String.IsNullOrEmpty(reference.ProjectCode)) return reference;

      return new TicketReference(currentProjectProvider.GetCurrentProject().Code, reference.TicketNumber);
    }

    public TicketReferenceQuery(ITicketReferenceParser parser,
                                IEntityData repo,
                                ICurrentProjectGetter currentProjectProvider)
    {
      if(currentProjectProvider == null)
        throw new ArgumentNullException(nameof(currentProjectProvider));
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      if(parser == null)
        throw new ArgumentNullException(nameof(parser));

      this.repo = repo;
      this.currentProjectProvider = currentProjectProvider;
      this.parser = parser;
    }
  }
}
