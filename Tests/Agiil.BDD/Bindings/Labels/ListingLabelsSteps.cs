using System;
using Agiil.BDD.Models.Labels;
using Agiil.BDD.Pages;
using Agiil.BDD.Personas;
using Agiil.BDD.Tasks.Labels;
using CSF.Collections;
using CSF.Screenplay;
using CSF.Screenplay.Selenium.Builders;
using NUnit.Framework;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Labels
{
  [Binding]
  public class ListingLabelsSteps
  {
    readonly IStage stage;
    readonly LabelNames labelNames;
    readonly LabelInfo labelInfo;

    #region Given

    [Given(@"(?:he|she|they) navigates? to the label list page")]
    public void GivenTheyNavigateToTheLabelListPage()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
			Given(theActor).WasAbleTo(OpenTheirBrowserOn.ThePage<Pages.LabelList>());
    }

    [Given(@"Youssef navigates to the label list page")]
    public void GivenYoussefNavigatesToTheLabelListPage()
    {
      var youssef = stage.ShineTheSpotlightOn<Youssef>();
			Given(youssef).WasAbleTo(OpenTheirBrowserOn.ThePage<Pages.LabelList>());
    }

    #endregion

    #region When

    [When(@"(?:he|she|they) reads? the list of available label names")]
    public void WhenTheyReadTheListOfAvailableLabelNames()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      var theNames = When(theActor).Gets(TheText.OfAll(LabelList.LabelNames));
      labelNames.Names.ReplaceContents(theNames);
    }

    [When(@"(?:he|she|they) reads? the number of(?: (open|closed)) tickets associated with '([^']+)'")]
    public void WhenTheyReadTheNumberOfOpenOrClosedTicketsForALabel(string openOrClosed, string labelName)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      labelInfo.Name = labelName;

      switch(openOrClosed)
      {
      case "open":
        labelInfo.TicketCount = When(theActor).Reads(TheTicketCount.ForTheTheLabel(labelName).WhichAreOpen());
        break;
      case "closed":
        labelInfo.TicketCount = When(theActor).Reads(TheTicketCount.ForTheTheLabel(labelName).WhichAreClosed());
        break;
      default:
        labelInfo.TicketCount = When(theActor).Reads(TheTicketCount.ForTheTheLabel(labelName).WhichAreOpenOrClosed());
        break;
      }
    }

    #endregion

    #region Then

    [Then(@"(?:he|she|they) should see that all of the following labels are included in the list:")]
    public void ThenTheyShouldSeeThatAllOfTheFollowingLabelsAreIncludedInTheList(Table expectedNamesTable)
    {
      var expectedNames = expectedNamesTable.ToListOfStrings();
      Assert.That(labelNames.Names, Is.SupersetOf(expectedNames));
    }

    [Then(@"(?:he|she|they) should see that there (?:is|are) (.*) tickets? associated with the label")]
    public void ThenTheyShouldSeeTheCountOfTicketsAssociatedWithTheLabel(int expectedTicketCount)
    {
      Assert.That(labelInfo.TicketCount, Is.EqualTo(expectedTicketCount));
    }

    [Then(@"(?:he|she|they) should see the label '(.*)'")]
    public void ThenTheyShouldSeeASpecificLabel(string expectedLabelName)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      var theNames = When(theActor).Gets(TheText.OfAll(LabelList.LabelNames));
      Assert.That(theNames, Contains.Item(expectedLabelName));
    }

    #endregion

    public ListingLabelsSteps(IStage stage, LabelNames labelNames, LabelInfo labelInfo)
    {
      if(labelInfo == null)
        throw new ArgumentNullException(nameof(labelInfo));
      if(labelNames == null)
        throw new ArgumentNullException(nameof(labelNames));
      if(stage == null)
        throw new ArgumentNullException(nameof(stage));

      this.labelInfo = labelInfo;
      this.labelNames = labelNames;
      this.stage = stage;
    }
  }
}
