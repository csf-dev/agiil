using System;
using System.Linq;
using CSF.Specifications;

namespace Agiil.Domain.Tickets
{
  public class SpecificationQueryProviderDecorator : IGetsQueryForTickets
  {
    readonly IGetsQueryForTickets decoratedInstance;
    readonly ISpecificationExpression<Ticket> specification;

    public IQueryable<Ticket> GetQuery() => decoratedInstance.GetQuery().Where(specification);

    public SpecificationQueryProviderDecorator(IGetsQueryForTickets decoratedInstance,
                                               ISpecificationExpression<Ticket> specification)
    {
      if(specification == null)
        throw new ArgumentNullException(nameof(specification));
      if(decoratedInstance == null)
        throw new ArgumentNullException(nameof(decoratedInstance));
      this.decoratedInstance = decoratedInstance;
      this.specification = specification;
    }
  }
}
