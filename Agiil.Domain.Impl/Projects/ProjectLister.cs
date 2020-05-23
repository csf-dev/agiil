using System;
using System.Collections.Generic;
using System.Linq;
using CSF.ORM;
using CSF.Specifications;

namespace Agiil.Domain.Projects
{
    public class ProjectLister : IGetsListOfProjects
    {
        readonly IEntityData data;
        readonly ISpecificationForProjectsWhichTheCurrentUserCanSeeInAList projectSpec;

        public IList<Project> GetsProjects()
        {
            return data.Query<Project>()
                .Where(projectSpec)
                .ToList();
        }

        public ProjectLister(IEntityData data, ISpecificationForProjectsWhichTheCurrentUserCanSeeInAList projectSpec)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
            this.projectSpec = projectSpec ?? throw new ArgumentNullException(nameof(projectSpec));
        }
    }
}
