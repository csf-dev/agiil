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
  public class CommentingOnATicketSteps
  {
    readonly IScreenplayScenario screenplay;

    [When(@"Youssef adds a comment with the text '([^']*)'")]
    public void WhenYoussefAddsACommentToTheTicket(string comment)
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(AddACommentToTheTicket.WithTheText(comment));
    }

    [When(@"Youssef edits the first editable comment")]
    public void WhenYoussefEditsTheMostRecentComment()
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo<BeginEditingTheFirstEditableComment>();
    }

    [When(@"Youssef changes the comment text to '([^']*)'")]
    public void WhenYoussefChangesTheCommentTextTo(string newCommentText)
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(ChangeTheCommentText.To(newCommentText));
    }

    [Then(@"Youssef should not see any editable comments")]
    public void ThenYoussefShouldNotSeeAnyEditableComments()
    {
      var youssef = screenplay.GetYoussef();
      Then(youssef).ShouldSee(Elements.InThePageBody()
                              .ThatAre(TicketDetail.Comments.EditCommentLink)
                              .Called("the edit comment links"))
                   .Elements
                   .Should()
                   .BeEmpty(because: "There should be no editable comments available");
    }

    [Then(@"Youssef should see an add-comment error message")]
    public void ThenYoussefShouldSeeAnAddCommentErrorMessage()
    {
      var youssef = screenplay.GetYoussef();
      Then(youssef).ShouldSee(TheText.Of(TicketDetail.AddCommentFeedbackMessage))
                   .Should()
                   .Be("Please enter a comment.", because: "The comment should not have been created.");
    }

    [Then(@"Youssef should see a comment-editing failure message")]
    public void ThenYoussefShouldSeeACommentEditingFailureMessage()
    {
      var youssef = screenplay.GetYoussef();
      Then(youssef).ShouldSee(TheVisibility.Of(EditComment.EditCommentFailureMessage))
                   .Should()
                   .BeTrue(because: "The failure message should be shown");
    }

    public CommentingOnATicketSteps(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));
      this.screenplay = screenplay;
    }
  }
}
