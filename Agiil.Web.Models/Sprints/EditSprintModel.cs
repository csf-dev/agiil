using System;
namespace Agiil.Web.Models.Sprints
{
  public class EditSprintModel : StandardPageModel
  {
    public EditSprintSpecification Specification { get; set; }

    public SprintDetailDto SprintDetail { get; set; }

    public EditSprintResponse Response { get; set; }
  }
}
