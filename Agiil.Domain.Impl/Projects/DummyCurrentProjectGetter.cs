using System;
using System.Linq;
using CSF.Data.Entities;

namespace Agiil.Domain.Projects
{
  public class DummyCurrentProjectGetter : ICurrentProjectGetter
  {
    readonly IRepository<Project> projectRepo;

    public Project GetCurrentProject()
    {
      return projectRepo.Query().FirstOrDefault();
    }

    public DummyCurrentProjectGetter(IRepository<Project> projectRepo)
    {
      if(projectRepo == null)
        throw new ArgumentNullException(nameof(projectRepo));
      
      this.projectRepo = projectRepo;
    }
  }
}
