using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
    public class StoryPointsIsOneOf : ISpecificationExpression<Ticket>
    {
        readonly IReadOnlyCollection<int> storyPoints;

        public Expression<Func<Ticket, bool>> GetExpression()
        {
            return t => t.StoryPoints.HasValue && storyPoints.Contains(t.StoryPoints.Value);
        }

        public StoryPointsIsOneOf(IReadOnlyCollection<int> storyPoints)
        {
            this.storyPoints = storyPoints ?? throw new ArgumentNullException(nameof(storyPoints));
        }
    }
}
