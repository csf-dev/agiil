using System;
using Agiil.Domain.Projects;

namespace Agiil.Domain.Tickets
{
  public class CurrentProjectBackfillingTicketReferenceParserDecorator : IParsesTicketReference
  {
    readonly IParsesTicketReference wrapped;
    readonly ICurrentProjectGetter currentProjectProvider;

    public string CreateReference(IIdentifiesTicketByProjectAndNumber ticket)
    {
      if(ticket == null) return null;
      return CreateReference(ticket.ProjectCode, ticket.TicketNumber);
    }

    public string CreateReference(string projectCode, long ticketNumber)
    {
      if(!String.IsNullOrEmpty(projectCode))
        return wrapped.CreateReference(projectCode, ticketNumber);

      return wrapped.CreateReference(GetProjectCode(), ticketNumber);
    }

    public TicketReference ParseReferece(string reference)
    {
      var result = wrapped.ParseReferece(reference);
      if(result == null) return result;
      if(result.ProjectCode != null) return result;

      return new TicketReference(GetProjectCode(), result.TicketNumber);
    }

    string GetProjectCode() => currentProjectProvider.GetCurrentProject()?.Code;

    public CurrentProjectBackfillingTicketReferenceParserDecorator(IParsesTicketReference wrapped,
                                                                   ICurrentProjectGetter currentProjectProvider)
    {
      if(currentProjectProvider == null)
        throw new ArgumentNullException(nameof(currentProjectProvider));
      if(wrapped == null)
        throw new ArgumentNullException(nameof(wrapped));
      this.wrapped = wrapped;
      this.currentProjectProvider = currentProjectProvider;
    }
  }
}
