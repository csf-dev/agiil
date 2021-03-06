﻿using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using Agiil.Tests.Attributes;
using CSF.ORM;
using Moq;
using NUnit.Framework;

namespace Agiil.Tests.Tickets
{
  [TestFixture,Parallelizable]
  public class TicketReferenceQueryTests
  {
    [Test, AutoMoqData]
    public void GetTicketByReference_uses_the_specification_factory_with_a_ref([InMemory] IEntityData repo,
                                                                               [TrueSpecExpr] ISpecForTicketReferenceEquality spec,
                                                                               TicketReference reference)
    {
      TicketReference refProvidedToFactory = null;
      var sut = new TicketReferenceQuery(repo, refParam => {
        refProvidedToFactory = refParam;
        return spec;
      });

      sut.GetTicketByReference(reference);

      Assert.That(refProvidedToFactory, Is.SameAs(reference));
    }

    [Test, AutoMoqData]
    public void GetTicketByReference_uses_spec_to_filter_entity_query_results([InMemory] IEntityData repo,
                                                                              Ticket ticketOne,
                                                                              Ticket ticketTwo,
                                                                              Ticket ticketThree,
                                                                              TicketReference reference)
    {
      var spec = Mock.Of<ISpecForTicketReferenceEquality>();
      Mock.Get(spec)
          .Setup(x => x.GetExpression())
          .Returns((Ticket x) => x == ticketTwo);
      repo.Add(ticketOne);
      repo.Add(ticketTwo);
      repo.Add(ticketThree);
      var sut = new TicketReferenceQuery(repo, refParam => spec);

      var result = sut.GetTicketByReference(reference);

      Assert.That(result, Is.SameAs(ticketTwo));
    }

    [Test, AutoMoqData]
    public void GetTicketByReference_returns_null_when_no_tickets_match([InMemory] IEntityData repo,
                                                                        TicketReference reference)
    {
      var spec = Mock.Of<ISpecForTicketReferenceEquality>();
            Mock.Get(spec)
                .Setup(x => x.GetExpression())
                .Returns((Ticket x) => false);
            var sut = new TicketReferenceQuery(repo, refParam => spec);

      var result = sut.GetTicketByReference(reference);

      Assert.That(result, Is.Null);
    }
  }
}
