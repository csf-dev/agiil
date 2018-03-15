using System;
using CSF.Screenplay.Selenium.Models;

namespace Agiil.BDD.Pages
{
  public static class AnyPage
  {
    public static ILocatorBasedTarget FooterApplicationVersion
    => new CssSelector(".PageFooter .ApplicationVersion", "the application version in the page footer");
  }
}
