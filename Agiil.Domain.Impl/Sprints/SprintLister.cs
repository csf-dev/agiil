using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Domain.Projects;
using CSF.ORM;
using CSF.Specifications;

namespace Agiil.Domain.Sprints
{
    public class SprintLister : ISprintLister
    {
        readonly IEntityData data;
        readonly IGetsCurrentProject currentProjectProvider;
        readonly Func<Project, ISpecForSprintInProject> projectSprintFactory;
        readonly Func<ISpecForOpenSprint> openSprintFactory;
        readonly Func<ISpecForClosedSprint> closedSprintFactory;

        public IList<Sprint> GetSprints(ListSprintsRequest request)
        {
            if(request == null)
                throw new ArgumentNullException(nameof(request));

            return data.Query<Sprint>()
                .Where(GetSpecification(request))
                .OrderBy(x => x.StartDate.HasValue ? x.StartDate : x.CreationDate)
                .ToList();
        }

        // If this method needs to become any more complex, then break it away to a service of its own which gets
        // a spec from a request.
        ISpecificationExpression<Sprint> GetSpecification(ListSprintsRequest request)
        {
            var project = GetProject(request);
            ISpecificationExpression<Sprint> spec = projectSprintFactory(project);

            if(!request.ShowOpenSprints)
                spec = spec.And(closedSprintFactory());

            if(!request.ShowClosedSprints)
                spec = spec.And(openSprintFactory());

            return spec;
        }

        Project GetProject(ListSprintsRequest request)
        {
            if(request.Project != null)
                return data.Theorise(request.Project);

            return currentProjectProvider.GetCurrentProject();
        }

        public SprintLister(IEntityData data,
                            IGetsCurrentProject currentProjectProvider,
                            Func<Project,ISpecForSprintInProject> projectSprintFactory,
                            Func<ISpecForOpenSprint> openSprintFactory,
                            Func<ISpecForClosedSprint> closedSprintFactory)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
            this.currentProjectProvider = currentProjectProvider ?? throw new ArgumentNullException(nameof(currentProjectProvider));
            this.projectSprintFactory = projectSprintFactory ?? throw new ArgumentNullException(nameof(projectSprintFactory));
            this.openSprintFactory = openSprintFactory ?? throw new ArgumentNullException(nameof(openSprintFactory));
            this.closedSprintFactory = closedSprintFactory ?? throw new ArgumentNullException(nameof(closedSprintFactory));
        }
    }
}
