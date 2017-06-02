using System;
using Agiil.Web.Controllers;
using Agiil.Web.Models.Sprints;

namespace Agiil.Tests.Sprints
{
  public class SprintEditingController : ISprintEditingController
  {
    readonly SprintController webController;

    public void Edit(EditSprintSpecification spec)
    {
      webController.Edit(spec);
    }

    public SprintEditingController(SprintController webController)
    {
      if(webController == null)
        throw new ArgumentNullException(nameof(webController));
      this.webController = webController;
    }
  }
}
