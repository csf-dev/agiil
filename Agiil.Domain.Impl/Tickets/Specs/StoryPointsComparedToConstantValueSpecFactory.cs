using System;
using Agiil.Domain.TicketSearch;
using CSF.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
    public class StoryPointsComparedToConstantValueSpecFactory : IGetsStoryPointsComparisonSpec
    {
        public ISpecificationExpression<Ticket> Equals(int value)
            => Spec.Expr<Ticket>(t => t.StoryPoints == value);

        public ISpecificationExpression<Ticket> GreaterThan(int value)
            => Spec.Expr<Ticket>(t => t.StoryPoints > value);

        public ISpecificationExpression<Ticket> GreaterThanOrEqual(int value)
            => Spec.Expr<Ticket>(t => t.StoryPoints >= value);

        public ISpecificationExpression<Ticket> LessThan(int value)
            => Spec.Expr<Ticket>(t => t.StoryPoints < value);

        public ISpecificationExpression<Ticket> LessThanOrEqual(int value)
            => Spec.Expr<Ticket>(t => t.StoryPoints <= value);

        public ISpecificationExpression<Ticket> NotEquals(int value)
            => Spec.Expr<Ticket>(t => t.StoryPoints != value);

        public ISpecificationExpression<Ticket> GetFromPredicateName(string predicateName, int value)
        {
            if(predicateName == PredicateName.Equals) return Equals(value);
            if(predicateName == PredicateName.NotEquals) return NotEquals(value);
            if(predicateName == PredicateName.GreaterThan) return GreaterThan(value);
            if(predicateName == PredicateName.GreaterThanOrEqual) return GreaterThanOrEqual(value);
            if(predicateName == PredicateName.LessThan) return LessThan(value);
            if(predicateName == PredicateName.LessThanOrEqual) return LessThanOrEqual(value);

            // This factory can't get a spec
            return null;
        }
    }
}
