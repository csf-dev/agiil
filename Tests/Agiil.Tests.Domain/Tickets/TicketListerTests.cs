using System;
using System.Linq;
using Agiil.Domain.Tickets;
using Agiil.Domain.TicketSearch;
using Agiil.Tests.Attributes;
using CSF.Data.Specifications;
using Moq;
using NUnit.Framework;

namespace Agiil.Tests.Tickets
{
  [TestFixture,Parallelizable]
  public class TicketListerTests
  {
    [Test,AutoMoqData]
    public void GetTickets_gets_specification_from_factory(IGetsTicketSpecification specProvider,
                                                           IGetsQueryForTickets queryProvider,
                                                           TicketListRequest request,
                                                           Search search)
    {
      // Arrange
      var specFactoryUsed = false;
      var specFactory = GetSpecFactory(s => {
        if(s != search) return null;
        specFactoryUsed = true;
        return specProvider;
      });
      Mock.Get(queryProvider).Setup(x => x.GetQuery()).Returns(() => null);
      var sut = new TicketLister(GetQueryProviderFactory(x => queryProvider), specFactory);
      request.SearchModel = search;

      // Act
      sut.GetTickets(request);

      // Assert
      Assert.That(specFactoryUsed, Is.True);
    }

    [Test,AutoMoqData]
    public void GetTickets_gets_query_provider_from_factory(IGetsTicketSpecification specProvider,
                                                            ISpecificationExpression<Ticket> spec,
                                                            IGetsQueryForTickets queryProvider,
                                                            TicketListRequest request)
    {
      // Arrange
      var queryProviderFactoryUsed = false;
      var specFactory = GetSpecFactory(s => specProvider);
      var queryProviderFactory = GetQueryProviderFactory(s => {
        if(s != spec) return null;
        queryProviderFactoryUsed = true;
        return queryProvider;
      });
      Mock.Get(specProvider).Setup(x => x.GetSpecification()).Returns(spec);
      Mock.Get(queryProvider).Setup(x => x.GetQuery()).Returns(() => null);
      var sut = new TicketLister(queryProviderFactory, specFactory);

      // Act
      sut.GetTickets(request);

      // Assert
      Assert.That(queryProviderFactoryUsed, Is.True);
    }

    [Test,AutoMoqData]
    public void GetTickets_returns_result_using_query(IGetsTicketSpecification specProvider,
                                                      IGetsQueryForTickets queryProvider,
                                                      TicketListRequest request,
                                                      Ticket ticket)
    {
      // Arrange
      var specFactory = GetSpecFactory(s => specProvider);
      var queryProviderFactory = GetQueryProviderFactory(s => queryProvider);
      var sut = new TicketLister(queryProviderFactory, specFactory);

      var query = new [] { ticket }.AsQueryable();
      Mock.Get(queryProvider).Setup(x => x.GetQuery()).Returns(query);

      // Act
      var result = sut.GetTickets(request);

      // Assert
      Assert.That(result.FirstOrDefault(), Is.EqualTo(ticket));
    }

    Func<Search, IGetsTicketSpecification> GetSpecFactory(Func<Search, IGetsTicketSpecification> func) => func;

    Func<ISpecificationExpression<Ticket>,IGetsQueryForTickets> GetQueryProviderFactory(Func<ISpecificationExpression<Ticket>,IGetsQueryForTickets> func) => func;
  }
}
