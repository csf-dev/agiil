using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Domain.TicketSearch;
using CSF.Data.NHibernate;
using CSF.Data.Specifications;

namespace Agiil.Domain.Tickets
{
  public class TicketLister : IGetsListOfTickets
  {
    readonly Func<ISpecificationExpression<Ticket>,IGetsQueryForTickets> queryProviderFactory;
    readonly Func<Search, IGetsTicketSpecification> specificationProviderFactory;

    public IReadOnlyList<Ticket> GetTickets(TicketListRequest request)
    {
      var specificationProvider = specificationProviderFactory(request?.SearchModel);
      return GetTickets(specificationProvider);
    }

    IReadOnlyList<Ticket> GetTickets(IGetsTicketSpecification specificationProvider)
    {
      if(specificationProvider == null) return new Ticket[0];

      var spec = specificationProvider.GetSpecification();
      var queryProvider = queryProviderFactory(spec);

      var query = queryProvider.GetQuery();
      if(query == null) return new Ticket[0];

      query = query.OrderByDescending(x => x.CreationTimestamp);
      return query
        .Fetch(x => x.User)
        .Fetch(x => x.Type)
        .FetchMany(x => x.PrimaryRelationships)
        .FetchMany(x => x.SecondaryRelationships)
        .ToList();
    }

    public TicketLister(Func<ISpecificationExpression<Ticket>,IGetsQueryForTickets> queryProviderFactory,
                        Func<Search,IGetsTicketSpecification> specificationProviderFactory)
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
