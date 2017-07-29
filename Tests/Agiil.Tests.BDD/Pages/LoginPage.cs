using System;
using CSF.Screenplay.Web.Models;

namespace Agiil.Tests.BDD.Pages
{
  public class LoginPage : Page
  {
    public override string GetName() => "the login page";

    public override IUriProvider GetUriProvider() => new AppUri("Login");

    public static ITarget Heading => new CssSelector(".page_content h1", "the page header");
  }
}
