using System;
using CSF.Entities;

namespace Agiil.Domain.Sprints
{
  public class EditSprintRequest
  {
    public IIdentity<Sprint> SprintIdentity { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool Closed { get; set; }
  }
}
