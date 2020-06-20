using System;
using System.Collections.Generic;

namespace Agiil.Domain.Projects
{
    public interface IGetsListOfProjects
    {
        IList<Project> GetsProjects();
    }
}
