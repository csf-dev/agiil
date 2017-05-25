﻿using System;
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

      var project = projectGetter.GetCurrentProject();

      return new Ticket
      {
        Title = title,
        Description = description,
        User = creator,
        CreationTimestamp = environment.GetCurrentUtcTimestamp(),
        Project = project,
        TicketNumber = (project != null)? project.NextAvailableTicketNumber++ : default(long),
      };
    }

    public TicketFactory(IEnvironment environment,
                         ICurrentProjectGetter projectGetter)
    {
      if(projectGetter == null)
        throw new ArgumentNullException(nameof(projectGetter));
      if(environment == null)
        throw new ArgumentNullException(nameof(environment));
      this.environment = environment;
      this.projectGetter = projectGetter;
    }
  }
}
