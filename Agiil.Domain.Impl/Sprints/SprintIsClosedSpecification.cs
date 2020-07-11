using System;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Domain.Sprints
{
    public interface ISpecForClosedSprint : ISpecificationExpression<Sprint> { }

    public class SprintIsClosedSpecification : ISpecForClosedSprint
    {
        public Expression<Func<Sprint, bool>> GetExpression()
            => x => x.Closed;
    }
}
