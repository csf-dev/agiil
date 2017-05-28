using System;
namespace Agiil.Tests.Sprints
{
  public class BulkSprintCreationSpecification
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
  }
}
