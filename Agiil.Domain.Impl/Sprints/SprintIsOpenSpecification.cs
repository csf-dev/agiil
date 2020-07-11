using System;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Domain.Sprints
{
    public interface ISpecForOpenSprint : ISpecificationExpression<Sprint> { }

    public class SprintIsOpenSpecification : ISpecForOpenSprint
    {
        public Expression<Func<Sprint, bool>> GetExpression()
            => x => !x.Closed;
    }
}
