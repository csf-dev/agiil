using System;
using Agiil.BDD.PageComponents;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;

namespace Agiil.BDD.Tasks.Auth
{
  public class LogOutOfTheSite : Performable
  {
    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(Navigate.ToAnotherPageByClicking(HeaderLoginLogoutWidget.OnAnyPage.LogoutButton));
    }
  }
}
