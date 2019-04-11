using System;
using Agiil.Domain.Projects;

namespace Agiil.Domain.Tickets
{
  public class CurrentProjectBackfillingTicketReferenceParserDecorator : IParsesTicketReference
  {
    readonly IParsesTicketReference wrapped;
    readonly ICurrentProjectGetter currentProjectProvider;

    public TicketReference GetReference(IIdentifiesTicketByProjectAndNumber ticket)
    {
      if(ticket == null) return null;
      return GetReference(ticket.ProjectCode, ticket.TicketNumber);
    }

    public TicketReference GetReference(string projectCode, long ticketNumber)
    {
      if(!String.IsNullOrEmpty(projectCode))
        return wrapped.GetReference(projectCode, ticketNumber);

      return wrapped.GetReference(GetProjectCode(), ticketNumber);
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
