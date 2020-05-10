using System;
using Agiil.Domain;
using Agiil.Domain.Tickets;
using Agiil.Domain.Validation;
using Agiil.Tests.Attributes;
using CSF.Validation;
using Moq;
using NUnit.Framework;
using AutoFixture.NUnit3;

namespace Agiil.Tests.Tickets
{
  [TestFixture,Parallelizable]
  public class CreateTicketRequestHandlerTests
  {

    [Test, AutoMoqData]
    public void Create_creates_ticket_from_factory_when_validation_passes(CreateTicketRequest request,
                                                                          [Frozen] ICreatesTicket ticketFactory,
                                                                          [Frozen,AlwaysPasses] ICreatesValidators<CreateTicketRequest> validatorFactory,
                                                                          Ticket ticket,
                                                                          CreateTicketRequestHandler sut)
    {
      // Arrange
      Mock.Get(ticketFactory)
          .Setup(x => x.CreateTicket(It.IsAny<CreateTicketRequest>()))
          .Returns(ticket);

      // Act
      sut.Create(request);

      // Assert
      Mock.Get(ticketFactory)
          .Verify(x => x.CreateTicket(request), Times.Once());
    }

    [Test, AutoMoqData]
    public void Create_does_not_use_factory_when_validation_fails(CreateTicketRequest request,
                                                                  [Frozen] ICreatesTicket ticketFactory,
                                                                  [Frozen] ICreatesValidators<CreateTicketRequest> validatorFactory,
                                                                  IValidator validator,
                                                                  Ticket ticket,
                                                                  CreateTicketRequestHandler sut)
    {
      // Arrange
      Mock.Get(ticketFactory)
          .Setup(x => x.CreateTicket(It.IsAny<CreateTicketRequest>()))
          .Returns(ticket);
      Mock.Get(validatorFactory)
          .Setup(x => x.GetValidator())
          .Returns(validator);
      Mock.Get(validator)
          .Setup(x => x.Validate(request))
          .Returns(Mock.Of<IValidationResult>(x => x.IsSuccess == false));

      // Act
      sut.Create(request);

      // Assert
      Mock.Get(ticketFactory)
          .Verify(x => x.CreateTicket(request), Times.Never());
    }

    [Test, AutoMoqData]
    public void Create_returns_created_ticket_in_response(CreateTicketRequest request,
                                                          [Frozen,AlwaysPasses] ICreatesValidators<CreateTicketRequest> validatorFactory,
                                                          [Frozen] ICreatesTicket ticketFactory,
                                                          [Frozen] ICreatesCreateTicketResponse responseFactory,
                                                          Ticket ticket,
                                                          CreateTicketRequestHandler sut)
    {
      // Arrange
      Mock.Get(ticketFactory)
          .Setup(x => x.CreateTicket(It.IsAny<CreateTicketRequest>()))
          .Returns(ticket);
      Mock.Get(responseFactory)
          .Setup(x => x.GetResponse(It.IsAny<IValidationResult>()))
          .Returns((IValidationResult r) => new CreateTicketResponse(r, Mock.Of<IValidationResultInterpreter>()));
      Mock.Get(responseFactory)
          .Setup(x => x.GetResponse(It.IsAny<IValidationResult>(), It.IsAny<Ticket>()))
          .Returns((IValidationResult r, Ticket t) => new CreateTicketResponse(r, Mock.Of<IValidationResultInterpreter>(), t));

      // Act
      var result = sut.Create(request);

      // Assert
      Assert.AreSame(ticket, result.Ticket);
    }

    [Test, AutoMoqData]
    public void Create_returns_a_response(CreateTicketRequest request,
                                          [Frozen,AlwaysPasses] ICreatesValidators<CreateTicketRequest> validatorFactory,
                                          [Frozen] ICreatesTicket ticketFactory,
                                          Ticket ticket,
                                          CreateTicketRequestHandler sut)
    {
      // Arrange
      Mock.Get(ticketFactory)
          .Setup(x => x.CreateTicket(It.IsAny<CreateTicketRequest>()))
          .Returns(ticket);

      // Act
      var result = sut.Create(request);

      // Assert
      Assert.NotNull(result);
    }

    [Test, AutoMoqData]
    public void Create_uses_a_validator(CreateTicketRequest request,
                                        [Frozen] ICreatesValidators<CreateTicketRequest> validatorFactory,
                                        IValidator validator,
                                        [Frozen] ICreatesTicket ticketFactory,
                                        Ticket ticket,
                                        CreateTicketRequestHandler sut)
    {
      // Arrange
      Mock.Get(ticketFactory)
          .Setup(x => x.CreateTicket(It.IsAny<CreateTicketRequest>()))
          .Returns(ticket);
      Mock.Get(validatorFactory)
          .Setup(x => x.GetValidator())
          .Returns(validator);

      // Act
      sut.Create(request);

      // Assert
      Mock.Get(validator)
          .Verify(x => x.Validate(request), Times.Once());
    }

    [Test, AutoMoqData]
    public void Create_returns_null_ticket_instance_if_validation_fails(CreateTicketRequest request,
                                                                        [Frozen] ICreatesValidators<CreateTicketRequest> validatorFactory,
                                                                        IValidator validator,
                                                                        [Frozen] ICreatesTicket ticketFactory,
                                                                        [Frozen] ICreatesCreateTicketResponse responseFactory,
                                                                        Ticket ticket,
                                                                        CreateTicketRequestHandler sut)
    {
      // Arrange
      Mock.Get(ticketFactory)
          .Setup(x => x.CreateTicket(It.IsAny<CreateTicketRequest>()))
          .Returns(ticket);
      Mock.Get(validatorFactory)
          .Setup(x => x.GetValidator())
          .Returns(validator);
      Mock.Get(validator)
          .Setup(x => x.Validate(request))
          .Returns(Mock.Of<IValidationResult>(x => x.IsSuccess == false));
      Mock.Get(responseFactory)
          .Setup(x => x.GetResponse(It.IsAny<IValidationResult>()))
          .Returns((IValidationResult r) => new CreateTicketResponse(r, Mock.Of<IValidationResultInterpreter>()));
      Mock.Get(responseFactory)
          .Setup(x => x.GetResponse(It.IsAny<IValidationResult>(), It.IsAny<Ticket>()))
          .Returns((IValidationResult r, Ticket t) => new CreateTicketResponse(r, Mock.Of<IValidationResultInterpreter>(), t));

      // Act
      var result = sut.Create(request);

      // Assert
      Assert.IsNull(result.Ticket);
    }
  }
}
