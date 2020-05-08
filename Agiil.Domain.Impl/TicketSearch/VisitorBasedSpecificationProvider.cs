using System;
using Agiil.Domain.Tickets;
using CSF.Specifications;

namespace Agiil.Domain.TicketSearch
{
  public class VisitorBasedSpecificationProvider : IGetsTicketSpecification
  {
    readonly Func<SpecificationBuildingSearchVisitor> visitorFactory;
    readonly Search search;

    public ISpecificationExpression<Ticket> GetSpecification()
    {
      var visitor = visitorFactory();
      search.Accept(visitor);
      return visitor.GetSpecification();
    }

    public VisitorBasedSpecificationProvider(Func<SpecificationBuildingSearchVisitor> visitorFactory,
                                             Search search)
    {
      if(search == null)
        throw new ArgumentNullException(nameof(search));
      if(visitorFactory == null)
        throw new ArgumentNullException(nameof(visitorFactory));
      
      this.visitorFactory = visitorFactory;
      this.search = search;
    }
  }
}
