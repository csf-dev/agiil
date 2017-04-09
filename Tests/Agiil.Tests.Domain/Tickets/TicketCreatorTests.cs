﻿using NUnit.Framework;
using System;
using NHibernate;
using Ploeh.AutoFixture.NUnit3;
using Agiil.Domain.Auth;
using Moq;
using Agiil.Domain.Tickets;
using Agiil.Domain.Data;

namespace Agiil.Tests.Domain.Tickets
{
  [TestFixture]
  public class TicketCreatorTests
  {
    [Test, AutoMoqData]
    public void Create_saves_newly_created_ticket([Frozen] ISession session,
                                                  [Frozen] ITicketFactory ticketFactory,
                                                  Ticket ticket,
                                                  CreateTicketRequest request,
                                                  [HasIdentity,LoggedIn] User user,
                                                  TicketCreator sut)
    {
      // Arrange
      Mock.Get(ticketFactory)
          .Setup(x => x.CreateTicket(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<User>()))
          .Returns(ticket);
      Mock.Get(session).Setup(x => x.Save(ticket));

      // Act
      var result = sut.Create(request);

      // Assert
      Mock.Get(session).Verify(x => x.Save(result), Times.Once());
    }

    [Test, AutoMoqData]
    public void Create_uses_ticket_factory(CreateTicketRequest request,
                                           [Frozen] ITicketFactory ticketFactory,
                                           Ticket ticket,
                                           [HasIdentity,LoggedIn] User user,
                                           TicketCreator sut)
    {
      // Arrange
      Mock.Get(ticketFactory)
          .Setup(x => x.CreateTicket(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<User>()))
          .Returns(ticket);
      
      // Act
      sut.Create(request);

      // Assert
      Mock.Get(ticketFactory)
          .Verify(x => x.CreateTicket(request.Title, request.Description, user), Times.Once());
    }

    [Test, AutoMoqData]
    public void Create_returns_created_ticket(CreateTicketRequest request,
                                              [Frozen] ITicketFactory ticketFactory,
                                              Ticket ticket,
                                              [HasIdentity,LoggedIn] User user,
                                              TicketCreator sut)
    {
      // Arrange
      Mock.Get(ticketFactory)
          .Setup(x => x.CreateTicket(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<User>()))
          .Returns(ticket);

      // Act
      var result = sut.Create(request);

      // Assert
      Assert.AreSame(ticket, result);
    }

    [Test, AutoMoqData]
    public void Create_uses_transaction(CreateTicketRequest request,
                                        [Frozen] ITicketFactory ticketFactory,
                                        Ticket ticket,
                                        [HasIdentity,LoggedIn] User user,
                                        [Frozen] ITransactionFactory transFactory,
                                        INestableTransaction trans,
                                        TicketCreator sut)
    {
      // Arrange
      Mock.Get(ticketFactory)
          .Setup(x => x.CreateTicket(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<User>()))
          .Returns(ticket);
      Mock.Get(transFactory)
          .Setup(x => x.BeginTransaction())
          .Returns(trans);
      Mock.Get(trans).Setup(x => x.RequestCommit());

      // Act
      sut.Create(request);

      // Assert
      Mock.Get(trans).Verify(x => x.RequestCommit(), Times.Once());
    }
  }
}
