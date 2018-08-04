﻿using System;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Creation;
using Agiil.Tests.Attributes;
using CSF.Data;
using CSF.Data.Entities;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Tickets.Creation
{
  [TestFixture,Parallelizable]
  public class PersistingTicketFactoryDecoratorTests
  {
    [Test, AutoMoqData]
    public void CreateTicket_saves_newly_created_ticket([Frozen] IEntityData repo,
                                                        [Frozen] ICreatesTicket ticketFactory,
                                                        Ticket ticket,
                                                        CreateTicketRequest request,
                                                        PersistingTicketFactoryDecorator sut)
    {
      // Arrange
      Mock.Get(ticketFactory)
          .Setup(x => x.CreateTicket(It.IsAny<CreateTicketRequest>()))
          .Returns(ticket);
      Mock.Get(repo).Setup(x => x.Add(ticket));

      // Act
      sut.CreateTicket(request);

      // Assert
      Mock.Get(repo).Verify(x => x.Add(ticket), Times.Once());
    }

    [Test, AutoMoqData]
    public void CreateTicket_uses_transaction(CreateTicketRequest request,
                                              [Frozen] ICreatesTicket ticketFactory,
                                              Ticket ticket,
                                              [Frozen] ITransactionCreator transFactory,
                                              ITransaction trans,
                                              PersistingTicketFactoryDecorator sut)
    {
      // Arrange
      Mock.Get(ticketFactory)
          .Setup(x => x.CreateTicket(It.IsAny<CreateTicketRequest>()))
          .Returns(ticket);
      Mock.Get(transFactory)
          .Setup(x => x.BeginTransaction())
          .Returns(trans);
      Mock.Get(trans).Setup(x => x.Commit());

      // Act
      sut.CreateTicket(request);

      // Assert
      Mock.Get(trans).Verify(x => x.Commit(), Times.Once());
    }
  }
}
