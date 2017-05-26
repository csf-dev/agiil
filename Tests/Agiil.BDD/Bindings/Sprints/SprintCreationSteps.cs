using System;
using Agiil.Tests.Sprints;
using Agiil.Web.Models.Sprints;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Agiil.BDD.Bindings.Sprints
{
  [Binding]
  public class SprintCreationSteps
  {
    readonly ISprintCreationController controller;

    [When("the user creates a sprint with the following details:")]
    public void WhenTheUserCreatesASprint(Table spec)
    {
      var request = spec.CreateInstance<NewSprintSpecification>();
      controller.Create(request);
    }

    public SprintCreationSteps(ISprintCreationController controller)
    {
      if(controller == null)
        throw new ArgumentNullException(nameof(controller));
      this.controller = controller;
    }
  }
}
