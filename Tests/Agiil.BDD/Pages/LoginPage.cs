using System;
using CSF.Screenplay.Selenium.Models;

namespace Agiil.BDD.Pages
{
  public class LoginPage : Page
  {
    public override string GetName() => "the login page";

    public override IUriProvider GetUriProvider() => new AppUri("Login");

    public static ITarget Heading => new CssSelector(".page_content h1", "the page header");

    public static ILocatorBasedTarget LoginFailureMessage
      => new CssSelector("#LoginForm .feedback.warning", "the login failure message");
  }
}
