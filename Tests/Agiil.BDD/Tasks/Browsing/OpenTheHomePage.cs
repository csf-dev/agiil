using System;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;

namespace Agiil.BDD.Tasks.Browsing
{
  public class OpenTheHomePage : Performable
  {
    protected override string GetReport(INamed actor)
      => $"{actor.Name} opens the Agiil home page.";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(OpenTheirBrowserOn.ThePage<HomePage>());
      actor.Perform(Wait.Until(HomePage.PageContentArea).IsVisible());
    }
  }
}
