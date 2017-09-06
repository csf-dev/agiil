using System;
using CSF.Screenplay;
using static CSF.Screenplay.StepComposer;
using TechTalk.SpecFlow;
using Agiil.BDD.Tasks.Tickets;
using CSF.Screenplay.Web.Builders;
using Agiil.BDD.Pages;
using FluentAssertions;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class CommentingOnATicket
  {
    readonly IScreenplayScenario screenplay;

    [When(@"Youssef adds a comment with the text '([^']*)'")]
    public void WhenYoussefAddsACommentToTheTicket(string comment)
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(AddACommentToTheTicket.WithTheText(comment));
    }

    [Then(@"Youssef should see an add-comment error message")]
    public void ThenYoussefShouldSeeAnAddCommentErrorMessage()
    {
      var youssef = screenplay.GetYoussef();
      Then(youssef).ShouldSee(TheText.Of(TicketDetail.AddCommentFeedbackMessage))
                   .Should()
                   .Be("The comment was not created", because: "The comment should not have been created.");
    }

    public CommentingOnATicket(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));
      this.screenplay = screenplay;
    }
  }
}
