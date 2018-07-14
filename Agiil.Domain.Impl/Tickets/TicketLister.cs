using System;
using System.Collections.Generic;
using System.Linq;
using CSF.Data.NHibernate;
using CSF.Data.Specifications;

namespace Agiil.Domain.Tickets
{
  public class TicketLister : IGetsListOfTickets
  {
    readonly Func<ISpecificationExpression<Ticket>,IGetsQueryForTickets> queryProviderFactory;
    readonly IGetsTicketSpecificationProvider specificationProviderFactory;

    public IReadOnlyList<Ticket> GetTickets(TicketListRequest request)
    {
      var specificationProvider = specificationProviderFactory.GetFromListRequest(request);
      return GetTickets(specificationProvider);
    }

    IReadOnlyList<Ticket> GetTickets(IGetsTicketSpecification specificationProvider)
    {
      var spec = specificationProvider.GetSpecification();
      var queryProvider = queryProviderFactory(spec);

      var query = queryProvider.GetQuery();
      query = query.OrderByDescending(x => x.CreationTimestamp);
      return query
        .Fetch(x => x.User)
        .Fetch(x => x.Type)
        .ToList();
    }

    public TicketLister(Func<ISpecificationExpression<Ticket>,IGetsQueryForTickets> queryProviderFactory,
                        IGetsTicketSpecificationProvider specificationProviderFactory)
    {
      if(specificationProviderFactory == null)
        throw new ArgumentNullException(nameof(specificationProviderFactory));
      if(queryProviderFactory == null)
        throw new ArgumentNullException(nameof(queryProviderFactory));
      
      this.queryProviderFactory = queryProviderFactory;
      this.specificationProviderFactory = specificationProviderFactory;
    }
  }
}
