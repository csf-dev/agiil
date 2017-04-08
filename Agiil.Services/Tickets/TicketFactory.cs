using System;
using Agiil.Domain;
using Agiil.Domain.Auth;
using Agiil.Domain.Tickets;

namespace Agiil.Services.Tickets
{
  public class TicketFactory : ITicketFactory
  {
    readonly IEnvironment environment;

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

      return new Ticket
      {
        Title = title,
        Description = description,
        User = creator,
        CreationTimestamp = environment.GetCurrentUtcTimestamp()
      };
    }

    public TicketFactory(IEnvironment environment)
    {
      if(environment == null)
        throw new ArgumentNullException(nameof(environment));
      this.environment = environment;
    }
  }
}
