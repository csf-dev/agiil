using System;
using CSF.Specifications;

namespace Agiil.Domain.Tickets
{
    public interface IGetsStoryPointsComparisonSpec
    {
        ISpecificationExpression<Ticket> Equals(int value);
        ISpecificationExpression<Ticket> NotEquals(int value);

        ISpecificationExpression<Ticket> GreaterThan(int value);
        ISpecificationExpression<Ticket> GreaterThanOrEqual(int value);
        ISpecificationExpression<Ticket> LessThan(int value);
        ISpecificationExpression<Ticket> LessThanOrEqual(int value);

        ISpecificationExpression<Ticket> GetFromPredicateName(string predicateName, int value);
    }
}
