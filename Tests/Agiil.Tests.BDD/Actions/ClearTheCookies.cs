using System;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Abilities;

namespace Agiil.Tests.BDD.Actions
{
  public class ClearTheCookies : Performable
  {
    bool allCookies;
    string named;

    protected override string GetReport(INamed actor)
    {
      if(allCookies)
        return $"{actor.Name} clears all browser cookies for the current site.";

      return $"{actor.Name} deletes the browser cookie '{named}'.";
    }

    protected override void PerformAs(IPerformer actor)
    {
      var browseTheWeb = actor.GetAbility<BrowseTheWeb>();

      var cookies = browseTheWeb.WebDriver.Manage().Cookies;

      if(allCookies)
        cookies.DeleteAllCookies();
      else
        cookies.DeleteCookieNamed(named);
    }

    public static IPerformable ForTheCurrentSite()
    {
      return new ClearTheCookies
      {
        allCookies = true,
        named = null,
      };
    }

    public static IPerformable Named(string named)
    {
      return new ClearTheCookies
      {
        allCookies = false,
        named = named,
      };
    }
  }
}
