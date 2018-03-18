using System;
using System.Linq;
using Agiil.Domain;
using Agiil.Domain.Auth;
using Agiil.Domain.Projects;
using Agiil.Domain.Tickets;
using CSF.Data.Entities;

namespace Agiil.Domain.Tickets
{
  public class TicketFactory : ITicketFactory
  {
    readonly IEnvironment environment;
    readonly ICurrentProjectGetter projectGetter;
    readonly ICurrentUserReader userReader;

    public Ticket CreateTicketForCurrentUser(string title, string description, TicketType type)
      => CreateTicket(title, description, userReader.RequireCurrentUser(), type);

    public Ticket CreateTicket(string title, string description, User creator, TicketType type)
    {
      var project = projectGetter.GetCurrentProject();

      return new Ticket
      {
        Title = title,
        Description = description,
        User = creator,
        CreationTimestamp = environment.GetCurrentUtcTimestamp(),
        Project = project,
        TicketNumber = (project != null)? project.NextAvailableTicketNumber++ : default(long),
        Type = type,
      };
    }

    public TicketFactory(IEnvironment environment,
                         ICurrentProjectGetter projectGetter,
                         ICurrentUserReader userReader)
    {
      if(userReader == null)
        throw new ArgumentNullException(nameof(userReader));
      if(projectGetter == null)
        throw new ArgumentNullException(nameof(projectGetter));
      if(environment == null)
        throw new ArgumentNullException(nameof(environment));
      this.userReader = userReader;
      this.environment = environment;
      this.projectGetter = projectGetter;
    }
  }
}
