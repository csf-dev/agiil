using System;
using Agiil.Domain.Projects;

namespace Agiil.Domain.Tickets.Creation
{
  public class CurrentProjectSettingTicketFactoryDecorator : ICreatesTicket
  {
    readonly ICreatesTicket wrappedInstance;
    readonly ICurrentProjectGetter projectGetter;

    public Ticket CreateTicket(CreateTicketRequest request)
    {
      var ticket = wrappedInstance.CreateTicket(request);

      var project = projectGetter.GetCurrentProject();
      var ticketNumber = (project != null)? project.NextAvailableTicketNumber++ : default(long);

      ticket.Project = project;
      ticket.TicketNumber = ticketNumber;

      return ticket;
    }

    public CurrentProjectSettingTicketFactoryDecorator(ICreatesTicket wrappedInstance, ICurrentProjectGetter projectGetter)
    {
      if(wrappedInstance == null)
        throw new ArgumentNullException(nameof(wrappedInstance));
      if(projectGetter == null)
        throw new ArgumentNullException(nameof(projectGetter));
      
      this.wrappedInstance = wrappedInstance;
      this.projectGetter = projectGetter;
    }
  }
}
