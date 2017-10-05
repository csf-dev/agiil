using System;
using Agiil.BDD.PageComponents;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;

namespace Agiil.BDD.Tasks.Auth
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
      actor.Perform(Enter.TheText(username).Into(HeaderLoginLogoutWidget.OnAnyPage.UsernameField));
      actor.Perform(Enter.TheText(password).Into(HeaderLoginLogoutWidget.OnAnyPage.PasswordField));
      actor.Perform(Navigate.ToAnotherPageByClicking(HeaderLoginLogoutWidget.OnAnyPage.LoginButton));
      actor.Perform(Wait.Until(LoginPage.Heading).IsVisible());
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
