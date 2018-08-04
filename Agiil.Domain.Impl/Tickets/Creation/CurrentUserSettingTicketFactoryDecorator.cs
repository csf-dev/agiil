using System;
using Agiil.Domain.Auth;

namespace Agiil.Domain.Tickets.Creation
{
  public class CurrentUserSettingTicketFactoryDecorator : ICreatesTicket
  {
    readonly ICreatesTicket wrappedInstance;
    readonly ICurrentUserReader userReader;

    public Ticket CreateTicket(CreateTicketRequest request)
    {
      var ticket = wrappedInstance.CreateTicket(request);
      ticket.User = userReader.RequireCurrentUser();
      return ticket;
    }

    public CurrentUserSettingTicketFactoryDecorator(ICreatesTicket wrappedInstance, ICurrentUserReader userReader)
    {
      if(userReader == null)
        throw new ArgumentNullException(nameof(userReader));
      if(wrappedInstance == null)
        throw new ArgumentNullException(nameof(wrappedInstance));
      this.wrappedInstance = wrappedInstance;
      this.userReader = userReader;
    }
  }
}
