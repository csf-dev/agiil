using System;
namespace Agiil.Web.Models.Sprints
{
  public class NewSprintSpecification
  {
    public string Name { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
  }
}
