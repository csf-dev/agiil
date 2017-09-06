using System;
using Agiil.BDD.Pages;
using Agiil.BDD.Tasks.Tickets;
using CSF.Screenplay;
using CSF.Screenplay.Web.Builders;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class ReadATicketSteps
  {
    readonly IScreenplayScenario screenplay;

    [When("Youssef opens a ticket with the title '([^']+)'")]
    public void WhenYoussefOpensATicketWithTheTitle(string title)
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(OpenTheTicket.Titled(title));
    }

    [Given("Youssef has opened a ticket with the title '([^']+)'")]
    public void GivenYoussefHasOpenedATicketWithTheTitle(string title)
    {
      var youssef = screenplay.GetYoussef();
      Given(youssef).WasAbleTo(OpenTheTicket.Titled(title));
    }

    [Then("Youssef should see that the ticket description reads '([^']*)'")]
    public void ThenYoussefShouldSeeThatTheTicketDescriptionIs(string description)
    {
      var youssef = screenplay.GetYoussef();
      Then(youssef).ShouldSee(TheTicket.Description())
                   .Should()
                   .Be(description);
    }

    [Then("Youssef should see that the ticket is part of the sprint '([^']+)'")]
    public void ThenYoussefShouldSeeThatTheTicketIsAPartOfTheSprint(string sprint)
    {
      var youssef = screenplay.GetYoussef();
      Then(youssef).ShouldSee(TheTicket.SprintTitle())
                   .Should()
                   .Be(sprint);
    }

    [Then("Youssef should see comments with the following text, in order")]
    public void ThenYoussefShouldSeeTheCommentsInOrder(Table expectedCommentsTable)
    {
      var expectedComments = expectedCommentsTable.CreateSet((TableRow arg) => arg[0]);

      var youssef = screenplay.GetYoussef();
      Then(youssef).ShouldSee(TheText.OfAll(TicketDetail.CommentBodies))
                   .Should()
                   .ContainInOrder(expectedComments);
    }

    [Then(@"Youssef should see that the ticket state is (.+)")]
    public void ThenYoussefShouldSeeThatTheTicketStateIs(string expectedState)
    {
      var youssef = screenplay.GetYoussef();
      Then(youssef).ShouldSee(TheText.Of(TicketDetail.TicketState))
                   .Should()
                   .Be(expectedState, because: "The ticket state should match");
    }

    public ReadATicketSteps(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));

      this.screenplay = screenplay;
    }
  }
}
