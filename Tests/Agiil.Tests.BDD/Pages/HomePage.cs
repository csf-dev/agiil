using System;
using Agiil.Tests.BDD.PageComponents;
using CSF.Screenplay.Web.Models;

namespace Agiil.Tests.BDD.Pages
{
  public class HomePage : Page
  {
    static HeaderLoginWidget headerLoginLogoutWidget = new HeaderLoginWidget();

    public override string GetName() => "the application home page";

    public override IUriProvider GetUriProvider() => new AppUri(String.Empty);

    public static ITarget PageContentArea => new CssSelector(".page_content", "the page content area");

    public static HeaderLoginWidget HeaderLoginLogoutWidget => headerLoginLogoutWidget;
  }
}
