using System;
using System.Linq;
using Agiil.Tests.Sprints;
using Agiil.Web.Models.Sprints;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Agiil.BDD.Bindings.Sprints
{
  [Binding]
  public class SprintQuerySteps
  {
    readonly Lazy<ISprintQueryController> controller;
    readonly Lazy<ISprintListController> listController;

    [When(@"the user visits the sprint list page")]
    public void WhenTheUserVisitsTheSprintListPage()
    {
      listController.Value.VisitSprintListControllerAndStoreListInContext();
    }

    [Then("a sprint exists with the following details:")]
    public void ThenASprintMustExist(Table spec)
    {
      var query = spec.CreateInstance<SprintSearchCriteria>();
      var result = controller.Value.DoesSprintExist(query);
      Assert.IsTrue(result);
    }

    [Then("no sprint should exist with the following details:")]
    public void ThenASprintMustNotExist(Table spec)
    {
      var query = spec.CreateInstance<SprintSearchCriteria>();
      var result = controller.Value.DoesSprintExist(query);
      Assert.IsFalse(result);
    }

    [Then("the following sprints should be listed, in order:")]
    public void ThenTheFollowingSprintsShouldBeDisplayedInOrder(Table sprintSpecs)
    {
      var sprints = sprintSpecs.CreateSet<SprintSummaryDto>().ToList();
      listController.Value.AssertThatSprintListMatchesExpected(sprints);
    }

    public SprintQuerySteps(Lazy<ISprintQueryController> controller,
                            Lazy<ISprintListController> listController)
    {
      if(listController == null)
        throw new ArgumentNullException(nameof(listController));
      if(controller == null)
        throw new ArgumentNullException(nameof(controller));
      this.controller = controller;
      this.listController = listController;
    }
  }
}
