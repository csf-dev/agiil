using System;
using CSF.Data.Specifications;

namespace Agiil.Domain.Tickets
{
  public interface IGetsTicketSpecification
  {
    ISpecificationExpression<Ticket> GetSpecification();
  }
}
