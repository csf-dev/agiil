using System;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;
using Agiil.BDD.Tasks.Browsing;
using CSF.Screenplay.Web.Builders;
using Agiil.BDD.Pages;
using CSF.Screenplay;

namespace Agiil.BDD.Bindings.Browsing
{
  [Binding]
  public class WebBrowsingSteps
  {
    readonly IScreenplayScenario screenplay;

    [Given(@"Joe has a clean web browser on the application home page")]
    public void GivenJoeHasACleanWebBrowserOnTheAppHomePage()
    {
      var joe = screenplay.GetJoe();
      Given(joe).WasAbleTo<VisitTheHomePageWithACleanBrowser>();
    }

    public WebBrowsingSteps(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));
      this.screenplay = screenplay;
    }
  }
}
