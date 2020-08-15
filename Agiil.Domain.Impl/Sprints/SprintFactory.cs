using System;
using Agiil.Domain.Projects;

namespace Agiil.Domain.Sprints
{
  public class SprintFactory : ISprintFactory
  {
    readonly IEnvironment environment;

    public Sprint CreateSprint(string name,
                               Project project,
                               DateTime? startDate = null,
                               DateTime? endDate = null)
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
        CreationDate = environment.GetCurrentUtcTimestamp(),
      };
    }

    public SprintFactory(IEnvironment environment)
    {
      if(environment == null)
        throw new ArgumentNullException(nameof(environment));
      this.environment = environment;
    }
  }
}
