using System;
using CSF.Screenplay.Web.Models;

namespace Agiil.Tests.BDD.PageComponents
{
  public class HeaderLoginWidget
  {
    public ITarget UsernameField => new CssSelector("#header_login_username", "the username field");
    public ITarget PasswordField => new CssSelector("#header_login_password", "the password field");
    public ITarget LoginButton => new CssSelector("body>header .login_logout_control button", "the login button");
    public ITarget CurrentLoginUsername => new CssSelector("body>header .login_logout_control p strong", "the currently-logged-in username");
  }
}
