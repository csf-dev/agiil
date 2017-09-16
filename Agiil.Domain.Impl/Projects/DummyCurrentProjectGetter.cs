using System;
using System.Linq;
using CSF.Data.Entities;

namespace Agiil.Domain.Projects
{
  public class DummyCurrentProjectGetter : ICurrentProjectGetter
  {
    readonly IEntityData projectRepo;

    public Project GetCurrentProject()
    {
      return projectRepo.Query<Project>().FirstOrDefault();
    }

    public DummyCurrentProjectGetter(IEntityData projectRepo)
    {
      if(projectRepo == null)
        throw new ArgumentNullException(nameof(projectRepo));
      
      this.projectRepo = projectRepo;
    }
  }
}
