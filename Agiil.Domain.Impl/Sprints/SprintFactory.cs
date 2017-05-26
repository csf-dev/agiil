using System;
using Agiil.Domain.Projects;

namespace Agiil.Domain.Sprints
{
  public class SprintFactory : ISprintFactory
  {
    public Sprint CreateSprint(string name,
                               Project project,
                               DateTime? startDate,
                               DateTime? endDate)
    {
      if(project == null)
        throw new ArgumentNullException(nameof(project));
      
      return new Sprint
      {
        Name = name,
        Description = null,
        Project = project,
        StartDate = startDate,
        EndDate = endDate,
      };
    }
  }
}
