using System;
namespace Agiil.Tests.Sprints
{
  public class SprintSearchCriteria
  {
    public string Name { get; set; }

    public long? Project { get; set; }

    public string Description { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
  }
}
