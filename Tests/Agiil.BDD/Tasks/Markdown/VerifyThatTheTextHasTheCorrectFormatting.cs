using System;
using System.Linq;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;
using CSF.Screenplay.Web.Models;
using CSF.Screenplay.Web.Queries;
using FluentAssertions;

namespace Agiil.BDD.Tasks.Markdown
{
  public class VerifyThatTheTextHasTheCorrectFormatting : Performable
  {
    readonly IWebElementAdapter container;
    readonly string expectedText;
    readonly string expectedTagName;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} verifies that the text '{expectedText}' in {container.GetName()} is displayed in a <{expectedTagName}> tag";

    protected override void PerformAs(IPerformer actor)
    {
      var element = GetMatchingElement(actor);
      var actualTagName = element.GetUnderlyingElement().TagName;

      actualTagName.Should().Be(expectedTagName, because: "the tag name should match");
    }

    IWebElementAdapter GetMatchingElement(IPerformer actor)
    {
      var elements = actor.Perform(Elements.In(container)
                                           .That(Matcher.Create(new TextQuery(), txt => txt == expectedText))
                                           .Called("the matching text"));

      elements.Elements
              .Should()
              .HaveCount(x => x >= 1, because: "there should be at least one piece of matching text");

      return elements.Elements.First();
    }

    internal VerifyThatTheTextHasTheCorrectFormatting(IWebElementAdapter container,
                                                      string expectedText,
                                                      string expectedTagName)
    {
      if(expectedTagName == null)
        throw new ArgumentNullException(nameof(expectedTagName));
      if(expectedText == null)
        throw new ArgumentNullException(nameof(expectedText));
      if(container == null)
        throw new ArgumentNullException(nameof(container));
      
      this.expectedTagName = expectedTagName;
      this.expectedText = expectedText;
      this.container = container;
    }
  }
}
