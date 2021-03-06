﻿using System;
using Agiil.Domain.Tickets;
using Agiil.Domain.Validation;
using Agiil.Tests.Attributes;
using AutoMapper;
using CSF.ORM;
using CSF.Entities;
using CSF.Validation;
using Moq;
using NUnit.Framework;
using AutoFixture.NUnit3;

namespace Agiil.Tests.Tickets
{
  [TestFixture,Parallelizable]
  public class EditTicketRequestHandlerTests
  {

    [Test, AutoMoqData]
    public void Edit_returns_a_result_when_validation_fails(EditTicketRequest request,
                                                            [Frozen] ICreatesValidators<EditTicketRequest> validatorFactory,
                                                            IValidator validator,
                                                            EditTicketRequestHandler sut)
    {
      // Arrange
      Mock.Get(validatorFactory)
          .Setup(x => x.GetValidator())
          .Returns(validator);
      Mock.Get(validator)
          .Setup(x => x.Validate(request))
          .Returns(Mock.Of<IValidationResult>(x => x.IsSuccess == false));

      // Act
      var result = sut.Edit(request);

      // Assert
      Assert.That(result, Is.Not.Null);
    }

    [Test, AutoMoqData]
    public void Edit_returns_response_with_null_ticket_when_validation_fails(EditTicketRequest request,
                                                                             [Frozen] ICreatesValidators<EditTicketRequest> validatorFactory,
                                                                             IValidator validator,
                                                                             [Frozen] ICreatesEditTicketResponse editResponseCreator,
                                                                             EditTicketRequestHandler sut)
    {
      // Arrange
      Mock.Get(validatorFactory)
          .Setup(x => x.GetValidator())
          .Returns(validator);
      Mock.Get(validator)
          .Setup(x => x.Validate(request))
          .Returns(Mock.Of<IValidationResult>(x => x.IsSuccess == false));

      // Act
      sut.Edit(request);

      // Assert
      Mock.Get(editResponseCreator)
          .Verify(x => x.GetResponse(It.IsAny<IValidationResult>(), null), Times.Once);
    }

    [Test, AutoMoqData]
    public void Edit_does_not_begin_transaction_when_validation_fails(EditTicketRequest request,
                                                                      [Frozen] ICreatesValidators<EditTicketRequest> validatorFactory,
                                                                      IValidator validator,
                                                                      [Frozen] IGetsTransaction transactionCreator,
                                                                      EditTicketRequestHandler sut)
    {
      // Arrange
      Mock.Get(validatorFactory)
          .Setup(x => x.GetValidator())
          .Returns(validator);
      Mock.Get(validator)
          .Setup(x => x.Validate(request))
          .Returns(Mock.Of<IValidationResult>(x => x.IsSuccess == false));

      // Act
      sut.Edit(request);

      // Assert
      Mock.Get(transactionCreator).Verify(x => x.GetTransaction(), Times.Never);
    }

    [Test, AutoMoqData]
    public void Edit_uses_transaction_when_validation_passes(EditTicketRequest request,
                                                             [Frozen,AlwaysPasses] ICreatesValidators<EditTicketRequest> validatorFactory,
                                                             [Frozen] ITransaction tran,
                                                             [Frozen,CreatesTransaction] IGetsTransaction transactionCreator,
                                                             EditTicketRequestHandler sut)
    {
      // Act
      sut.Edit(request);

      // Assert
      Mock.Get(transactionCreator).Verify(x => x.GetTransaction(), Times.Once);
      Mock.Get(tran).Verify(x => x.Commit(), Times.Once);
    }

    [Test, AutoMoqData]
    public void Edit_passes_correct_ticket_to_editing_service(EditTicketRequest request,
                                                              [Frozen,AlwaysPasses] ICreatesValidators<EditTicketRequest> validatorFactory,
                                                              [Frozen,CreatesTransaction] IGetsTransaction transactionCreator,
                                                              [InMemory,Frozen] IEntityData data,
                                                              Ticket ticket,
                                                              [Frozen] IEditsTicket editor,
                                                              EditTicketRequestHandler sut)
    {
      // Arrange
      data.Add(ticket);
      request.Identity = ticket.GetIdentity();

      // Act
      sut.Edit(request);

      // Assert
      Mock.Get(editor).Verify(x => x.Edit(ticket, request), Times.Once);
    }

    [Test, AutoMoqData]
    public void Edit_returns_edited_ticket_in_response(EditTicketRequest request,
                                                       [Frozen,AlwaysPasses] ICreatesValidators<EditTicketRequest> validatorFactory,
                                                       [Frozen,CreatesTransaction] IGetsTransaction transactionCreator,
                                                       [InMemory,Frozen] IEntityData data,
                                                       [HasIdentity] Ticket ticket,
                                                       [Frozen] ICreatesEditTicketResponse editResponseCreator,
                                                       EditTicketRequestHandler sut)
    {
      // Arrange
      data.Add(ticket);
      request.Identity = ticket.GetIdentity();

      // Act
      sut.Edit(request);

      // Assert
      Mock.Get(editResponseCreator)
          .Verify(x => x.GetResponse(It.IsAny<IValidationResult>(), ticket), Times.Once);
    }
  }
}
