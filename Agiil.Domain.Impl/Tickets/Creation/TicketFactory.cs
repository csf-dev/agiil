using System;

namespace Agiil.Domain.Tickets.Creation
{
  public class TicketFactory : ICreatesTicket
  {
    readonly IEnvironment environment;

    public Ticket CreateTicket(CreateTicketRequest request)
    {
      return new Ticket
      {
        Title = request.Title,
        Description = request.Description,
        CreationTimestamp = environment.GetCurrentUtcTimestamp(),
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
