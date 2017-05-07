﻿using NUnit.Framework;
using System;
using NHibernate;
using Ploeh.AutoFixture.NUnit3;
using Agiil.Domain.Auth;
using Moq;
using Agiil.Domain.Tickets;
using CSF.Validation;
using CSF.Data.Entities;
using CSF.Data;

namespace Agiil.Tests.Domain.Tickets
{
  [TestFixture]
  public class TicketCreatorTests
  {
    [Test, AutoMoqData]
    public void Create_saves_newly_created_ticket([Frozen] IRepository<Ticket> repo,
                                                  [Frozen] ITicketFactory ticketFactory,
                                                  [Frozen] ICreateTicketValidatorFactory validatorFactory,
                                                  Ticket ticket,
                                                  CreateTicketRequest request,
                                                  [HasIdentity,LoggedIn] User user,
                                                  TicketCreator sut)
    {
      // Arrange
      Mock.Get(ticketFactory)
          .Setup(x => x.CreateTicket(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<User>()))
          .Returns(ticket);
      Mock.Get(repo).Setup(x => x.Add(ticket));
      SetupValidatorWhichAlwaysPasses(validatorFactory);

      // Act
      sut.Create(request);

      // Assert
      Mock.Get(repo).Verify(x => x.Add(ticket), Times.Once());
    }

    [Test, AutoMoqData]
    public void Create_uses_ticket_factory(CreateTicketRequest request,
                                           [Frozen] ITicketFactory ticketFactory,
                                           [Frozen] ICreateTicketValidatorFactory validatorFactory,
                                           Ticket ticket,
                                           [HasIdentity,LoggedIn] User user,
                                           TicketCreator sut)
    {
      // Arrange
      Mock.Get(ticketFactory)
          .Setup(x => x.CreateTicket(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<User>()))
          .Returns(ticket);
      SetupValidatorWhichAlwaysPasses(validatorFactory);

      // Act
      sut.Create(request);

      // Assert
      Mock.Get(ticketFactory)
          .Verify(x => x.CreateTicket(request.Title, request.Description, user), Times.Once());
    }

    [Test, AutoMoqData]
    public void Create_returns_created_ticket_in_response(CreateTicketRequest request,
                                                          [Frozen] ICreateTicketValidatorFactory validatorFactory,
                                                          [Frozen] ITicketFactory ticketFactory,
                                                          Ticket ticket,
                                                          [HasIdentity,LoggedIn] User user,
                                                          TicketCreator sut)
    {
      // Arrange
      Mock.Get(ticketFactory)
          .Setup(x => x.CreateTicket(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<User>()))
          .Returns(ticket);
      SetupValidatorWhichAlwaysPasses(validatorFactory);

      // Act
      var result = sut.Create(request);

      // Assert
      Assert.AreSame(ticket, result.Ticket);
    }

    [Test, AutoMoqData]
    public void Create_returns_a_response(CreateTicketRequest request,
                                          [Frozen] ICreateTicketValidatorFactory validatorFactory,
                                          [Frozen] ITicketFactory ticketFactory,
                                          Ticket ticket,
                                          [HasIdentity,LoggedIn] User user,
                                          TicketCreator sut)
    {
      // Arrange
      Mock.Get(ticketFactory)
          .Setup(x => x.CreateTicket(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<User>()))
          .Returns(ticket);
      SetupValidatorWhichAlwaysPasses(validatorFactory);

      // Act
      var result = sut.Create(request);

      // Assert
      Assert.NotNull(result);
    }

    [Test, AutoMoqData]
    public void Create_uses_a_validator(CreateTicketRequest request,
                                        [Frozen] ICreateTicketValidatorFactory validatorFactory,
                                        [Frozen] ITicketFactory ticketFactory,
                                        Ticket ticket,
                                        [HasIdentity,LoggedIn] User user,
                                        TicketCreator sut)
    {
      // Arrange
      Mock.Get(ticketFactory)
          .Setup(x => x.CreateTicket(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<User>()))
          .Returns(ticket);
      var validator = SetupValidatorWhichAlwaysPasses(validatorFactory);

      // Act
      sut.Create(request);

      // Assert
      Mock.Get(validator)
          .Verify(x => x.Validate(request), Times.Once());
    }

    [Test, AutoMoqData]
    public void Create_does_not_persist_if_validation_fails(CreateTicketRequest request,
                                                            [Frozen] IRepository<Ticket> repo,
                                                            [Frozen] ICreateTicketValidatorFactory validatorFactory,
                                                            [Frozen] ITicketFactory ticketFactory,
                                                            Ticket ticket,
                                                            [HasIdentity,LoggedIn] User user,
                                                            TicketCreator sut)
    {
      // Arrange
      Mock.Get(ticketFactory)
          .Setup(x => x.CreateTicket(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<User>()))
          .Returns(ticket);
      var validator = SetupValidatorWhichAlwaysPasses(validatorFactory);
      Mock.Get(validator)
          .Setup(x => x.Validate(request))
          .Returns(Mock.Of<IValidationResult>(x => x.IsSuccess == false));

      // Act
      sut.Create(request);

      // Assert
      Mock.Get(repo)
          .Verify(x => x.Add(It.IsAny<Ticket>()), Times.Never());
    }

    [Test, AutoMoqData]
    public void Create_returns_null_ticket_instance_if_validation_fails(CreateTicketRequest request,
                                                                        [Frozen] ICreateTicketValidatorFactory validatorFactory,
                                                                        [Frozen] ITicketFactory ticketFactory,
                                                                        Ticket ticket,
                                                                        [HasIdentity,LoggedIn] User user,
                                                                        TicketCreator sut)
    {
      // Arrange
      Mock.Get(ticketFactory)
          .Setup(x => x.CreateTicket(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<User>()))
          .Returns(ticket);
      var validator = SetupValidatorWhichAlwaysPasses(validatorFactory);
      Mock.Get(validator)
          .Setup(x => x.Validate(request))
          .Returns(Mock.Of<IValidationResult>(x => x.IsSuccess == false));

      // Act
      var result = sut.Create(request);

      // Assert
      Assert.IsNull(result.Ticket);
    }

    [Test, AutoMoqData]
    public void Create_uses_transaction(CreateTicketRequest request,
                                        [Frozen] ICreateTicketValidatorFactory validatorFactory,
                                        [Frozen] ITicketFactory ticketFactory,
                                        Ticket ticket,
                                        [HasIdentity,LoggedIn] User user,
                                        [Frozen] ITransactionCreator transFactory,
                                        CSF.Data.ITransaction trans,
                                        TicketCreator sut)
    {
      // Arrange
      Mock.Get(ticketFactory)
          .Setup(x => x.CreateTicket(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<User>()))
          .Returns(ticket);
      Mock.Get(transFactory)
          .Setup(x => x.BeginTransaction())
          .Returns(trans);
      Mock.Get(trans).Setup(x => x.Commit());
      SetupValidatorWhichAlwaysPasses(validatorFactory);

      // Act
      sut.Create(request);

      // Assert
      Mock.Get(trans).Verify(x => x.Commit(), Times.Once());
    }

    IValidator SetupValidatorWhichAlwaysPasses(ICreateTicketValidatorFactory factory)
    {
      var validator = Mock.Of<IValidator>(x => x.Validate(It.IsAny<object>()).IsSuccess == true);

      Mock.Get(factory)
          .Setup(x => x.GetValidator())
          .Returns(validator);

      return validator;
    }
  }
}
