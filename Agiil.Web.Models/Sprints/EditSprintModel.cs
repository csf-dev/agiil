using System;
namespace Agiil.Web.Models.Sprints
{
  public class EditSprintModel
  {
    public EditSprintSpecification Specification { get; set; }

    public SprintDetailDto Sprint { get; set; }

    public EditSprintResponse Response { get; set; }
  }
}
