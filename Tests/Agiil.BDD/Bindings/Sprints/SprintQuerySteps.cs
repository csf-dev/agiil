using System;
using Agiil.Tests.Sprints;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Agiil.BDD.Bindings.Sprints
{
  [Binding]
  public class SprintQuerySteps
  {
    readonly ISprintQueryController controller;

    [Then("a sprint exists with the following details:")]
    public void ThenASprintMustExist(Table spec)
    {
      var query = spec.CreateInstance<SprintSearchCriteria>();
      var result = controller.DoesSprintExist(query);
      Assert.IsTrue(result);
    }

    [Then("no sprint should exist with the following details:")]
    public void ThenASprintMustNotExist(Table spec)
    {
      var query = spec.CreateInstance<SprintSearchCriteria>();
      var result = controller.DoesSprintExist(query);
      Assert.IsFalse(result);
    }

    public SprintQuerySteps(ISprintQueryController controller)
    {
      if(controller == null)
        throw new ArgumentNullException(nameof(controller));
      this.controller = controller;
    }
  }
}
