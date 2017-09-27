using System;
using System.Linq;
using Agiil.BDD.Pages;
using Agiil.BDD.Tasks.Markdown;
using Agiil.BDD.Tasks.Tickets;
using CSF.Screenplay;
using CSF.Screenplay.Web.Builders;
using CSF.Screenplay.Web.Models;
using CSF.Screenplay.Web.Queries;
using FluentAssertions;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class ReadingACommentSteps
  {
    const string CurrentCommentKey = "The current comment";
    
    readonly IScreenplayScenario scenario;
    readonly ScenarioContext context;

    [Then(@"Youssef reads the first comment on the ticket '([^']+)'")]
    public void ThenYoussefReadsTheFirstCommentOnTheTicket(string ticketName)
    {
      var youssef = scenario.GetYoussef();
      Then(youssef).Should(OpenTheTicket.Titled(ticketName));
      var elements = Then(youssef).ShouldSee(Elements.InThePageBody()
                                                     .ThatAre(TicketDetail.CommentBodies)
                                                     .Called("the comments"));
      context.Set(elements.Elements.First(), CurrentCommentKey);
    }

    [Then(@"Youssef should see that the comment text '([^']+)' is displayed in a bold font")]
    public void ThenYoussefShouldSeeThatSomeCommentTextIsBold(string text)
    {
      var youssef = scenario.GetYoussef();
      var comment = GetCurrentComment();
      Then(youssef).Should(VerifyThat.TheRenderedText(text).Inside(comment).IsDisplayedWithinTheTag("strong"));
    }

    [Then(@"Youssef should see that the comment text '([^']+)' is displayed in an italic font")]
    public void ThenYoussefShouldSeeThatSomeCommentTextIsItalic(string text)
    {
      var youssef = scenario.GetYoussef();
      var comment = GetCurrentComment();
      Then(youssef).Should(VerifyThat.TheRenderedText(text).Inside(comment).IsDisplayedWithinTheTag("em"));
    }

    IWebElementAdapter GetCurrentComment()
    {
      var currentCommentElement = context.Get<IWebElementAdapter>(CurrentCommentKey);
      if(currentCommentElement == null)
        throw new InvalidOperationException("There is no current comment");

      return currentCommentElement;
    }

    public ReadingACommentSteps(IScreenplayScenario scenario, ScenarioContext context)
    {
      if(context == null)
        throw new ArgumentNullException(nameof(context));
      if(scenario == null)
        throw new ArgumentNullException(nameof(scenario));

      this.scenario = scenario;
      this.context = context;
    }
  }
}
