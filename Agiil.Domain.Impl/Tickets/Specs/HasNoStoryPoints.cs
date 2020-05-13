using System;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
    public class HasNoStoryPoints : ISpecificationExpression<Ticket>
    {
        public Expression<Func<Ticket, bool>> GetExpression() => t => !t.StoryPoints.HasValue;
    }
}
