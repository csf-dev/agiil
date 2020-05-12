using System;
using Agiil.BDD.PageComponents;
using CSF.Screenplay.Selenium.Models;

namespace Agiil.BDD.Pages
{
  public class HomePage : Page
  {
    static HeaderLoginLogoutWidget headerLoginLogoutWidget = new HeaderLoginLogoutWidget();

    public override string GetName() => "the application home page";

    public override IUriProvider GetUriProvider() => new AppUri(String.Empty);

    public static ITarget PageContentArea => new CssSelector(".content_container", "the page content area");

    public static HeaderLoginLogoutWidget HeaderLoginLogoutWidget => headerLoginLogoutWidget;
  }
}
