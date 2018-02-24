using System;
using Agiil.BDD.PageComponents;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;
using FluentAssertions;

namespace Agiil.BDD.Tasks.Auth
{
  public class VerifyThatTheyAreNotLoggedIn : Performable
  {
    protected override string GetReport(INamed actor)
      => $"{actor.Name} ensures that they are not logged in.";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(TheVisibility.Of(HeaderLoginLogoutWidget.OnAnyPage.CurrentLoginUsername))
           .Should()
           .BeFalse($"{actor.Name} should not be logged in, so they should not see a logged-in username");
    }
  }
}
