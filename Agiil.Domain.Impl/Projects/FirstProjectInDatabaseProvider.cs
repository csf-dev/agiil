using System;
using System.Linq;
using CSF.ORM;

namespace Agiil.Domain.Projects
{
  public class FirstProjectInDatabaseProvider : ICurrentProjectGetter
  {
    readonly IEntityData projectRepo;

    public Project GetCurrentProject()
    {
      return projectRepo.Query<Project>().FirstOrDefault();
    }

    public FirstProjectInDatabaseProvider(IEntityData projectRepo)
    {
      if(projectRepo == null)
        throw new ArgumentNullException(nameof(projectRepo));
      
      this.projectRepo = projectRepo;
    }
  }
}
