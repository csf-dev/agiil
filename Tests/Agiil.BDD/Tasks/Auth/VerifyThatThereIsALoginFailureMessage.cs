using System;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;
using CSF.Screenplay.Web.Queries;
using FluentAssertions;

namespace Agiil.BDD.Tasks.Auth
{
  public class VerifyThatThereIsALoginFailureMessage : Performable
  {
    protected override string GetReport(INamed actor)
      => $"{actor.Name} looks for the login failure message and ensures that there is one.";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(TheVisibility.Of(LoginPage.LoginFailureMessage))
           .Should()
           .BeTrue("The failure message should be displayed on the page");
    }
  }
}
