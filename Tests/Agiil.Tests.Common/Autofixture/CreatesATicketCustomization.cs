using System;
using Agiil.Domain.Tickets;
using Moq;
using Ploeh.AutoFixture;

namespace Agiil.Tests.Autofixture
{
  public class CreatesATicketCustomization : ICustomization
  {
    public void Customize(IFixture fixture)
    {
      fixture.Customize<ICreatesTicket>(c => {
        return c .FromFactory((Ticket ticket) => {
          return Mock.Of<ICreatesTicket>(x => x.CreateTicket(It.IsAny<CreateTicketRequest>()) == ticket);
        });
      });
    }
  }
}
