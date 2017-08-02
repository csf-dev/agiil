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

    protected override string GetReport(INamed actor)
    {
      if(password == null)
        return $"{actor.Name} logs into the site as '{username}' and no password.";
      else
        return $"{actor.Name} logs into the site as '{username}' with the password '{password}'.";
    }

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(OpenTheirBrowserOn.ThePage<HomePage>());
      actor.Perform(Wait.For(HomePage.PageContentArea).IsVisible());
      actor.Perform(Enter.TheText(username).Into(HomePage.HeaderLoginLogoutWidget.UsernameField));
      actor.Perform(Enter.TheText(password).Into(HomePage.HeaderLoginLogoutWidget.PasswordField));
      actor.Perform(Click.On(HomePage.HeaderLoginLogoutWidget.LoginButton));
    }

    public static LogIntoTheSite As(string username)
    {
      if(username == null)
        throw new ArgumentNullException(nameof(username));
      
      return new LogIntoTheSite {
        username = username,
      };
    }

    public IPerformable WithThePassword(string password)
    {
      this.password = password;
      return this;
    }
  }
}
