using System;
using CSF.Specifications;

namespace Agiil.Domain.Tickets
{
  public interface IGetsTicketSpecification
  {
    ISpecificationExpression<Ticket> GetSpecification();
  }
}
