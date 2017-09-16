using System;
namespace Agiil.BDD.Models.Sprints
{
  public class SprintDetails
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
  }
}
