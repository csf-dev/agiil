using System;
using Agiil.Tests.BDD.Actions;
using Agiil.Tests.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;

namespace Agiil.Tests.BDD.Auth
{
  public class ResetTheirBrowser : Performable
  {
    protected override string GetReport(INamed actor) => $"{actor.Name} resets their web browser.";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(OpenTheirBrowserOn.ThePage<HomePage>());
      actor.Perform(Wait.For(HomePage.PageContentArea).IsVisible());
      actor.Perform(ClearTheCookies.ForTheCurrentSite());
    }

    public static IPerformable Now()
    {
      return new ResetTheirBrowser();
    }
  }
}
