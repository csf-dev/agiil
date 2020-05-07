using System;
using Agiil.Domain.Tickets;
using Agiil.Tests.Attributes;
using Agiil.Web.Models.Tickets;
using Agiil.Web.Services.Tickets;
using AutoMapper;
using CSF.ORM;
using Moq;
using NUnit.Framework;
using AutoFixture.NUnit3;

namespace Agiil.Tests.Web.Services.Tickets
{
  [TestFixture,Parallelizable]
  public class TicketDetailDtoProviderTests
  {
    [Test, AutoMoqData]
    public void GetTicketDetailDto_returns_null_when_the_reference_is_null([Frozen] IGetsTicketByReference ticketProvider,
                                                                           TicketDetailDtoProvider sut)
    {
      Mock.Get(ticketProvider)
          .Setup(x => x.GetTicketByReference((TicketReference) null))
          .Returns(() => null);
      var result = sut.GetTicketDetailDto(null);
      Assert.That(result, Is.Null);
    }

    [Test, AutoMoqData]
    public void GetTicketDetailDto_returns_null_when_the_ticket_is_not_found([Frozen] IGetsTicketByReference ticketProvider,
                                                                             TicketDetailDtoProvider sut,
                                                                             TicketReference reference)
    {
      Mock.Get(ticketProvider)
          .Setup(x => x.GetTicketByReference(reference))
          .Returns(() => null);
      var result = sut.GetTicketDetailDto(reference);
      Assert.That(result, Is.Null);
    }

    [Test, AutoMoqData]
    public void GetTicketDetailDto_returns_mapped_dto_when_ticket_exists([Frozen] IGetsTicketByReference ticketProvider,
                                                                         [Frozen,InMemory] IEntityData data,
                                                                         [Frozen] IMapper mapper,
                                                                         TicketDetailDtoProvider sut,
                                                                         TicketReference reference,
                                                                         TicketDetailDto dto,
                                                                         Ticket ticket)
    {
      Mock.Get(ticketProvider)
          .Setup(x => x.GetTicketByReference(reference))
          .Returns(ticket);
      data.Add(ticket);
      Mock.Get(mapper)
          .Setup(x => x.Map<TicketDetailDto>(ticket))
          .Returns(dto);
      var result = sut.GetTicketDetailDto(reference);
      Assert.That(result, Is.SameAs(dto));
    }
  }
}
