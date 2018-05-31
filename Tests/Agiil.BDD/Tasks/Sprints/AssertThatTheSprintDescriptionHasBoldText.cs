using System;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;
using CSF.Screenplay.Selenium.Models;
using FluentAssertions;

namespace Agiil.BDD.Tasks.Sprints
{
  public class AssertThatTheSprintDescriptionHasBoldText : Performable
  {
    static readonly ILocatorBasedTarget Bold = new CssSelector("strong", "bold");

    readonly string expectedBoldText;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} asserts that the sprint description includes the text '{expectedBoldText}' in a bold font";

		protected override void PerformAs(IPerformer actor)
    {
      var boldElements = actor.Perform(Elements.In(SprintDetail.Description).ThatAre(Bold).Called("the bold text"));
      var boldTexts = actor.Perform(TheText.OfAll(boldElements));

      boldTexts.Should().Contain(expectedBoldText, because: $"The word '{expectedBoldText}' should be bold");
    }

    public AssertThatTheSprintDescriptionHasBoldText(string expectedBoldText)
    {
      if(expectedBoldText == null)
        throw new ArgumentNullException(nameof(expectedBoldText));
      this.expectedBoldText = expectedBoldText;
    }

    public static Performable WithTheText(string expectedBoldText)
    => new AssertThatTheSprintDescriptionHasBoldText(expectedBoldText);
  }
}
