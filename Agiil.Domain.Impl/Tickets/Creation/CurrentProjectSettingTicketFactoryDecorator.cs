using System;
using Agiil.Domain.Projects;
using log4net;

namespace Agiil.Domain.Tickets.Creation
{
  public class CurrentProjectSettingTicketFactoryDecorator : ICreatesTicket
  {
    readonly ICreatesTicket wrappedInstance;
    readonly IGetsCurrentProject projectGetter;
    private readonly ILog logger;

    public Ticket CreateTicket(CreateTicketRequest request)
    {
      var ticket = wrappedInstance.CreateTicket(request);

      var project = projectGetter.GetCurrentProject();
      logger.DebugFormat("Next available ticket number: {0}", project?.NextAvailableTicketNumber);
      var ticketNumber = (project != null)? project.NextAvailableTicketNumber++ : default(long);

      ticket.Project = project;
      ticket.TicketNumber = ticketNumber;

      return ticket;
    }

    public CurrentProjectSettingTicketFactoryDecorator(ICreatesTicket wrappedInstance,
                                                       IGetsCurrentProject projectGetter,
                                                       ILog logger)
    {
      if(logger == null)
        throw new ArgumentNullException(nameof(logger));
      if(wrappedInstance == null)
        throw new ArgumentNullException(nameof(wrappedInstance));
      if(projectGetter == null)
        throw new ArgumentNullException(nameof(projectGetter));
      
      this.wrappedInstance = wrappedInstance;
      this.projectGetter = projectGetter;
      this.logger = logger;
    }
  }
}
