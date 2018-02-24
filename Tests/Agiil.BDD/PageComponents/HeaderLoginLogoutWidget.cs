using System;
using CSF.Screenplay.Selenium.Models;

namespace Agiil.BDD.PageComponents
{
  public class HeaderLoginLogoutWidget
  {
    static HeaderLoginLogoutWidget singleton = new HeaderLoginLogoutWidget();

    public ILocatorBasedTarget UsernameField
      => new CssSelector("#header_login_username", "the username field");

    public ILocatorBasedTarget PasswordField
      => new CssSelector("#header_login_password", "the password field");

    public ILocatorBasedTarget LoginButton
      => new CssSelector("#HeaderLoginButton", "the login button");

    public ILocatorBasedTarget CurrentLoginUsername
      => new CssSelector("body>header .login_logout_control p strong", "the currently-logged-in username");

    public ILocatorBasedTarget LogoutButton
      => new CssSelector("#HeaderLogoutButton", "the logout button");

    public static HeaderLoginLogoutWidget OnAnyPage => singleton;
  }
}
