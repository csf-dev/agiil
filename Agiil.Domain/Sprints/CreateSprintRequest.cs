using System;
using Agiil.Domain.Projects;
using CSF.Entities;

namespace Agiil.Domain.Sprints
{
  public class CreateSprintRequest
  {
    public IIdentity<Project> Project { get; set; }

    public string Name { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
  }
}
