using System;
using static CSF.Screenplay.StepComposer;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using CSF.Screenplay;
using CSF.Screenplay.Web.Builders;
using Agiil.BDD.Pages;
using System.Linq;
using FluentAssertions;

namespace Agiil.BDD.Bindings.Sprints
{
  [Binding]
  public class SprintViewingSteps
  {
    readonly IScreenplayScenario screenplay;

    [When(@"Youssef opens the sprint listing page")]
    public void WhenYoussedOpensTheSprintListingPage()
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(OpenTheirBrowserOn.ThePage(SprintList.ForOpenSprints()));
    }

    [When(@"Youssef opens the sprint listing page for closed sprints")]
    public void WhenYoussedOpensTheSprintListingPageForClosedSprints()
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(OpenTheirBrowserOn.ThePage(SprintList.ForClosedSprints()));
    }

    [Then(@"Youssef should see the following sprints, in order")]
    public void ThenYoussefShouldSeeTheSprintsInOrder(Table expectedSprintNamesTable)
    {
      var expectedSprintNames = expectedSprintNamesTable.CreateSet<string>().ToArray();

      var youssef = screenplay.GetYoussef();
      Then(youssef).ShouldSee(TheText.OfAll(SprintList.SprintNames))
                   .Should()
                   .ContainInOrder(expectedSprintNames, because: "The displayed sprints should match the expectation");
    }

    public SprintViewingSteps(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));

      this.screenplay = screenplay;
    }
  }
}
