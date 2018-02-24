using System;
using System.Linq;
using Agiil.BDD.Pages;
using Agiil.BDD.Tasks.Markdown;
using Agiil.BDD.Tasks.Tickets;
using CSF.Screenplay;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Selenium.Builders;
using CSF.Screenplay.Selenium.Models;
using CSF.Screenplay.Selenium.Queries;
using FluentAssertions;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class ReadingCommentSteps
  {
    const string CurrentCommentKey = "The current comment";
    
    readonly IStage stage;
    readonly ScenarioContext context;

    [Then(@"(?:he|she|they) reads? the first comment on the ticket '([^']+)'")]
    public void ThenTheyReadTheFirstCommentOnTheTicket(string ticketName)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).Should(OpenTheTicket.Titled(ticketName));
      var elements = Then(theActor).ShouldSee(Elements.InThePageBody()
                                                     .ThatAre(TicketDetail.CommentBodies)
                                                     .Called("the comments"));
      context.Set(elements.Elements.First(), CurrentCommentKey);
    }

    [Then(@"(?:he|she|they) should see that the comment text '([^']+)' is displayed in a bold font")]
    public void ThenTheyShouldSeeThatSomeCommentTextIsBold(string text)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      var comment = GetCurrentComment();
      Then(theActor).Should(VerifyThat.TheRenderedText(text).Inside(comment).IsDisplayedWithinTheTag("strong"));
    }

    [Then(@"(?:he|she|they) should see that the comment text '([^']+)' is displayed in an italic font")]
    public void ThenTheyShouldSeeThatSomeCommentTextIsItalic(string text)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      var comment = GetCurrentComment();
      Then(theActor).Should(VerifyThat.TheRenderedText(text).Inside(comment).IsDisplayedWithinTheTag("em"));
    }

    [Then("(?:he|she|they) should see comments with the following text, in order")]
    public void ThenTheyShouldSeeTheCommentsInOrder(Table expectedCommentsTable)
    {
      var expectedComments = expectedCommentsTable
        .Rows
        .Select(x => x.Values.Single())
        .ToArray();

      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(TheText.OfAll(TicketDetail.CommentBodies))
                   .Should()
                   .ContainInOrder(expectedComments);
    }

    [Then(@"(?:he|she|they) should see that the ticket has no comments")]
    public void ThenTheyShouldSeeThatTheTicketHasNoComments()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      var comments = Then(theActor).ShouldSee(Elements.InThePageBody()
                                             .ThatAre(TicketDetail.CommentBodies)
                                             .Called("the comment bodies"));
      comments.Elements.Should().BeEmpty(because: "there are no comments");
    }

    IWebElementAdapter GetCurrentComment()
    {
      var currentCommentElement = context.Get<IWebElementAdapter>(CurrentCommentKey);
      if(currentCommentElement == null)
        throw new InvalidOperationException("There is no current comment");

      return currentCommentElement;
    }

    public ReadingCommentSteps(ScenarioContext context, IStage stage)
    {
      if(context == null)
        throw new ArgumentNullException(nameof(context));
      if(stage == null)
        throw new ArgumentNullException(nameof(stage));

      this.context = context;
      this.stage = stage;
    }
  }
}
