using System;
namespace Agiil.Domain.Sprints
{
  public interface ISprintFactory
  {
    Sprint CreateSprint(string name,
                        Projects.Project project,
                        DateTime? startDate = null,
                        DateTime? endDate = null);
  }
}
