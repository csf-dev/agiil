using System;
using Agiil.Tests.Projects;
using TechTalk.SpecFlow;

namespace Agiil.BDD.Bindings.Projects
{
  [Binding]
  public class ProjectCreationSteps
  {
    readonly IProjectCreationController controller;

    [Given(@"the current project has an ID of (\d+)")]
    public void GivenTheCurrentProjectHasAnId(long id)
    {
      controller.SetupProjectAndMakeCurrent(id);
    }

    public ProjectCreationSteps(IProjectCreationController controller)
    {
      if(controller == null)
        throw new ArgumentNullException(nameof(controller));
      this.controller = controller;
    }
  }
}
