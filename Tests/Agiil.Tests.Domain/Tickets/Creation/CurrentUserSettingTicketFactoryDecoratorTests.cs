using System;
using Agiil.Domain.Auth;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Creation;
using Agiil.Tests.Attributes;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Tickets.Creation
{
  [TestFixture,Parallelizable]
  public class CurrentUserSettingTicketFactoryDecoratorTests
  {
    [Test,AutoMoqData]
    public void CreateTicket_sets_user_from_current_user_provider([Frozen,CreatesATicket] ICreatesTicket wrapped,
                                                                  [LoggedIn] User user,
                                                                  CreateTicketRequest request,
                                                                  CurrentUserSettingTicketFactoryDecorator sut)
    {
      // Act
      var result = sut.CreateTicket(request);

      // Assert
      Assert.That(result?.User, Is.SameAs(user));
    }
  }
}
