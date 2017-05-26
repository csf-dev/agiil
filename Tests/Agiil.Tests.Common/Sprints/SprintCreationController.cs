using System;
using Agiil.Web.Controllers;
using Agiil.Web.Models.Sprints;

namespace Agiil.Tests.Sprints
{
  public class SprintCreationController : ISprintCreationController
  {
    readonly NewSprintController controller;

    public void Create(NewSprintSpecification spec)
    {
      controller.Index(spec);
    }

    public SprintCreationController(NewSprintController controller)
    {
      if(controller == null)
        throw new ArgumentNullException(nameof(controller));
      this.controller = controller;
    }
  }
}
