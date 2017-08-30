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

    [Given(@"([A-Za-z0-9_-]+) has a clean web browser on the application home page")]
    public void GivenJoeHasACleanWebBrowserOnTheAppHomePage(string actorName)
    {
      var joe = screenplay.GetJoe(actorName);
      Given(joe).WasAbleTo<VisitTheHomePageWithACleanBrowser>();
    }

    [Given("([A-Za-z0-9_-]+) opens (?:his|her) browser on the change password page")]
    public void GivenJoeOpensTheChangePasswordPage(string actorName)
    {
      var joe = screenplay.GetJoe(actorName);
      Given(joe).WasAbleTo(OpenTheirBrowserOn.ThePage<ChangePasswordPage>());
    }

    public WebBrowsingSteps(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));
      this.screenplay = screenplay;
    }
  }
}
