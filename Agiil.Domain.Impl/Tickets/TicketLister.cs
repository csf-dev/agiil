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

    public IReadOnlyList<Ticket> GetTickets(TicketListRequest request)
    {
      return GetTickets(request?.CriteriaModel);
    }

    IReadOnlyList<Ticket> GetTickets(IGetsTicketSpecification specificationProvider)
    {
      if(specificationProvider == null) return new Ticket[0];

      var spec = specificationProvider.GetSpecification();
      var queryProvider = queryProviderFactory(spec);

      var query = queryProvider.GetQuery();
      query = query.OrderByDescending(x => x.CreationTimestamp);
      return query
        .Fetch(x => x.User)
        .Fetch(x => x.Type)
        .ToList();
    }

    public TicketLister(Func<ISpecificationExpression<Ticket>,IGetsQueryForTickets> queryProviderFactory)
    {
      if(queryProviderFactory == null)
        throw new ArgumentNullException(nameof(queryProviderFactory));
      
      this.queryProviderFactory = queryProviderFactory;
    }
  }
}
