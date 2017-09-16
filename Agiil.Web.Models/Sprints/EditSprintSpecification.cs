using System;
namespace Agiil.Web.Models.Sprints
{
  public class EditSprintSpecification
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool Closed { get; set; }

    public string StartDateWebValue => StartDate.ToWebDateValue();
    public string EndDateWebValue => EndDate.ToWebDateValue();
  }
}
