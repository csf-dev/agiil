using System;
using Agiil.Domain.Tickets;
using CSF.Specifications;

namespace Agiil.Domain.TicketSearch
{
  public interface IConvertsCriterionToSpecification
  {
    ISpecificationExpression<Ticket> ConvertToSpecification(Criterion criterion);
  }
}
