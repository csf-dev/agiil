using System;
using Agiil.Tests.Sprints;
using Agiil.Web.Models.Sprints;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Agiil.BDD.Bindings.Sprints
{
  [Binding]
  public class SprintEditingSteps
  {
    readonly ISprintEditingController controller;

    [When("the user attempts to edit a sprint with the following specification:")]
    public void WhenTheUserAttemptsToEditASprint(Table specTable)
    {
      var spec = specTable.CreateInstance<EditSprintSpecification>();
      controller.Edit(spec);
    }

    public SprintEditingSteps(ISprintEditingController controller)
    {
      if(controller == null)
        throw new ArgumentNullException(nameof(controller));
      this.controller = controller;
    }
  }
}
