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
    readonly IRepository<Project> projectRepo;

    public Ticket CreateTicket(string title, string description, User creator)
    {
      if(title == null)
      {
        throw new ArgumentNullException(nameof(title));
      }
      if(creator == null)
      {
        throw new ArgumentNullException(nameof(creator));
      }

      var project = projectRepo.Query().First();

      return new Ticket
      {
        Title = title,
        Description = description,
        User = creator,
        CreationTimestamp = environment.GetCurrentUtcTimestamp(),
        Project = project,
      };
    }

    public TicketFactory(IEnvironment environment,
                         IRepository<Project> projectRepo)
    {
      if(projectRepo == null)
        throw new ArgumentNullException(nameof(projectRepo));
      if(environment == null)
        throw new ArgumentNullException(nameof(environment));
      this.environment = environment;
      this.projectRepo = projectRepo;
    }
  }
}
