using System;
using Agiil.BDD.PageComponents;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;
using CSF.Screenplay.Web.Queries;
using FluentAssertions;

namespace Agiil.BDD.Tasks.Auth
{
  public class VerifyThatTheyAreLoggedIn : Performable
  {
    string expectedUsername;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} ensures that they are logged in with the username '{expectedUsername}'.";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(TheText.Of(HeaderLoginLogoutWidget.OnAnyPage.CurrentLoginUsername))
           .Should()
           .Be(expectedUsername, because: $"{actor.Name} should see that their username is '{expectedUsername}'.");
    }

    VerifyThatTheyAreLoggedIn(string username)
    {
      this.expectedUsername = username;
    }

    public static IPerformable As(string username)
    {
      return new VerifyThatTheyAreLoggedIn(username);
    }
  }
}
