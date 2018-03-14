using System;
namespace Agiil.Web.Models.Sprints
{
  public class NewSprintModel : PageModel
  {
    public NewSprintSpecification Specification { get; set; }

    public NewSprintResult Result { get; set; }
  }
}
