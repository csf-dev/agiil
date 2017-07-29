using System;
using Agiil.Tests.BDD.Actions;
using Agiil.Tests.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;

namespace Agiil.Tests.BDD.Auth
{
  public class LogIntoTheSite : Performable
  {
    string username, password;

    protected override string GetReport(INamed actor) => $"{actor.Name} logs into the site with '{username}'/'{password}'.";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(OpenTheirBrowserOn.ThePage<HomePage>());
      actor.Perform(Wait.ForAtMost(TimeSpan.FromSeconds(30)).Until(HomePage.PageContentArea).IsVisible());
      actor.Perform(ClearTheCookies.ForTheCurrentSite());
      actor.Perform(OpenTheirBrowserOn.ThePage<HomePage>());
      actor.Perform(Wait.ForAtMost(TimeSpan.FromSeconds(4)).Until(HomePage.PageContentArea).IsVisible());
      actor.Perform(Enter.TheText(username).Into(HomePage.HeaderLoginLogoutWidget.UsernameField));
      actor.Perform(Enter.TheText(password).Into(HomePage.HeaderLoginLogoutWidget.PasswordField));
      actor.Perform(Click.On(HomePage.HeaderLoginLogoutWidget.LoginButton));
    }

    public static IPerformable WithTheUsernameAndPassword(string username, string password)
    {
      return new LogIntoTheSite
      {
        username = username,
        password = password
      };
    }
  }
}
