using System;
using static CSF.Screenplay.StepComposer;
using TechTalk.SpecFlow;
using Agiil.BDD.Tasks.Tickets;
using Agiil.BDD.Pages;
using FluentAssertions;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Selenium.Builders;
using CSF.Screenplay;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class CommentingOnATicketSteps
  {
    readonly ICast cast;
    readonly IStage stage;

    [When(@"(?:he|she|they) adds? a comment with the text '([^']*)'")]
    public void WhenTheyAddACommentToTheTicket(string comment)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      When(theActor).AttemptsTo(AddACommentToTheTicket.WithTheText(comment));
    }

    [When(@"(?:he|she|they) edits? the first editable comment")]
    public void WhenTheyEditTheMostRecentComment()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      When(theActor).AttemptsTo<BeginEditingTheFirstEditableComment>();
    }

    [When(@"(?:he|she|they) deletes? the first editable comment")]
    public void WhenTheyDeleteTheMostRecentComment()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      When(theActor).AttemptsTo<DeleteTheFirstDeletableComment>();
    }

    [When(@"(?:he|she|they) changes? the comment text to '([^']*)'")]
    public void WhenTheyChangeTheCommentTextTo(string newCommentText)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      When(theActor).AttemptsTo(ChangeTheCommentText.To(newCommentText));
    }

    [Then(@"(?:he|she|they) should not see any editable comments")]
    public void ThenTheyShouldNotSeeAnyEditableComments()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(Elements.InThePageBody()
                              .ThatAre(TicketDetail.Comments.EditCommentLink)
                              .Called("the edit comment links"))
                   .Elements
                   .Should()
                   .BeEmpty(because: "there should be no editable comments available");
    }

    [Then(@"(?:he|she|they) should not see any comments which may be deleted")]
    public void ThenTheyShouldNotSeeAnyDeletableComments()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(Elements.InThePageBody()
                              .ThatAre(TicketDetail.Comments.DeleteCommentButton)
                              .Called("the delete comment buttons"))
                   .Elements
                   .Should()
                   .BeEmpty(because: "there should be no deletable comments available");
    }

    [Then(@"(?:he|she|they) should see an add-comment error message")]
    public void ThenTheyShouldSeeAnAddCommentErrorMessage()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(TheText.Of(TicketDetail.AddCommentFeedbackMessage))
                   .Should()
                   .Be("Please enter a comment.", because: "The comment should not have been created.");
    }

    [Then(@"(?:he|she|they) should see a comment-editing failure message")]
    public void ThenTheyShouldSeeACommentEditingFailureMessage()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(TheVisibility.Of(EditComment.EditCommentFailureMessage))
                   .Should()
                   .BeTrue(because: "The failure message should be shown");
    }

    public CommentingOnATicketSteps(ICast cast, IStage stage)
    {
      if(stage == null)
        throw new ArgumentNullException(nameof(stage));
      if(cast == null)
        throw new ArgumentNullException(nameof(cast));

      this.cast = cast;
      this.stage = stage;
    }
  }
}
