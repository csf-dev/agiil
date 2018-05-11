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
    readonly IEntityData data;
    readonly IEnvironment environment;
    readonly ICurrentProjectGetter projectGetter;
    readonly ICurrentUserReader userReader;

    [Obsolete("Instead, use an overload which takes a CreateTicketRequest")]
    public Ticket CreateTicketForCurrentUser(string title, string description, TicketType type)
      => CreateTicket(title, description, userReader.RequireCurrentUser(), type);

    [Obsolete("Instead, use an overload which takes a CreateTicketRequest")]
    public Ticket CreateTicket(string title, string description, User creator, TicketType type)
    {
      var request = new CreateTicketRequest {
        Title = title,
        Description = description,
      };

      var ticket = CreateTicket(request, creator);
      ticket.Type = type;
      return ticket;
    }

    public Ticket CreateTicketForCurrentUser(CreateTicketRequest request)
      => CreateTicket(request, userReader.RequireCurrentUser());

    public Ticket CreateTicket(CreateTicketRequest request, User creator)
    {
      var project = projectGetter.GetCurrentProject();

      var type = data.Theorise(request.TicketTypeIdentity);

      var ticket = new Ticket
      {
        Title = request.Title,
        Description = request.Description,
        User = creator,
        CreationTimestamp = environment.GetCurrentUtcTimestamp(),
        Project = project,
        TicketNumber = (project != null)? project.NextAvailableTicketNumber++ : default(long),
        Type = type,
      };

      if(request.SprintIdentity != null)
        ticket.Sprint = data.Theorise(request.SprintIdentity);

      return ticket;
    }

    public TicketFactory(IEnvironment environment,
                         ICurrentProjectGetter projectGetter,
                         ICurrentUserReader userReader,
                         IEntityData data)
    {
      if(data == null)
        throw new ArgumentNullException(nameof(data));
      if(userReader == null)
        throw new ArgumentNullException(nameof(userReader));
      if(projectGetter == null)
        throw new ArgumentNullException(nameof(projectGetter));
      if(environment == null)
        throw new ArgumentNullException(nameof(environment));
      
      this.data = data;
      this.userReader = userReader;
      this.environment = environment;
      this.projectGetter = projectGetter;
    }
  }
}
