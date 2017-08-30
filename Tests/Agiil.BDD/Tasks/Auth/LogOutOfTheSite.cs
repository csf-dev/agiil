using System;
using Agiil.BDD.PageComponents;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;

namespace Agiil.BDD.Tasks.Auth
{
  public class LogOutOfTheSite : Performable
  {
    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(Click.On(HeaderLoginLogoutWidget.OnAnyPage.LogoutButton));
    }
  }
}
