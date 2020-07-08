using System;
using System.Linq.Expressions;
using Agiil.Domain.Projects;
using CSF.Specifications;

namespace Agiil.Domain.Sprints
{
    public interface ISpecForSprintInProject : ISpecificationExpression<Sprint> { }

    public class SprintIsForProjectSpecification : ISpecForSprintInProject
    {
        readonly Project project;

        public Expression<Func<Sprint, bool>> GetExpression()
            => x => x.Project == project;

        public SprintIsForProjectSpecification(Project project)
        {
            this.project = project ?? throw new ArgumentNullException(nameof(project));
        }
    }
}
