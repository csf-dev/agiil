using System;
using CSF.Screenplay;
using TechTalk.SpecFlow;

namespace Agiil.BDD.Bindings.Labels
{
  [Binding]
  public class ListingLabelsSteps
  {
    readonly IStage stage;

    #region Given

    [Given(@"(?:he|she|they) (?:has|have) set the ticket labels to read '([^']+)' and submitted")]
    public void GivenTheyHaveSetTheTicketLabelsAndSubmitted(string labelNames)
    {
      ScenarioContext.Current.Pending();
    }

    [Given(@"(?:he|she|they) navigates? to the label list page")]
    public void GivenTheyNavigateToTheLabelListPage()
    {
      ScenarioContext.Current.Pending();
    }

    [Given(@"Youssef navigates to the label list page")]
    public void GivenYoussefNavigatesToTheLabelListPage()
    {
      ScenarioContext.Current.Pending();
    }

    #endregion

    #region When

    [When(@"(?:he|she|they) reads? the list of available label names")]
    public void WhenTheyReadTheListOfAvailableLabelNames()
    {
      ScenarioContext.Current.Pending();
    }

    [When(@"(?:he|she|they) reads? the number of (open|closed) tickets associated with '([^']+)'")]
    public void WhenTheyReadTheNumberOfOpenOrClosedTicketsForALabel(string openOrClosed, string labelName)
    {
      ScenarioContext.Current.Pending();
    }

    #endregion

    #region Then

    [Then(@"(?:he|she|they) should see that all of the following labels are included in the list:")]
    public void ThenTheyShouldSeeThatAllOfTheFollowingLabelsAreIncludedInTheList(Table table)
    {
      ScenarioContext.Current.Pending();
    }

    [Then(@"(?:he|she|they) should see that there (?:is|are) (.*) tickets? associated with the label")]
    public void ThenTheyShouldSeeTheCountOfTicketsAssociatedWithTheLabel(int expectedTicketCount)
    {
      ScenarioContext.Current.Pending();
    }

    [Then(@"(?:he|she|they) should see the label '(.*)'")]
    public void ThenTheyShouldSeeASpecificLabel(string expectedLabelName)
    {
      ScenarioContext.Current.Pending();
    }

    #endregion

    public ListingLabelsSteps(IStage stage)
    {
      if(stage == null)
        throw new ArgumentNullException(nameof(stage));

      this.stage = stage;
    }
  }
}
