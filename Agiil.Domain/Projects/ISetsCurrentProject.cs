using System;
using CSF.Entities;

namespace Agiil.Domain.Projects
{
    public interface ISetsCurrentProject
    {
        void SetCurrentProject(IIdentity<Project> projectId);
    }
}
