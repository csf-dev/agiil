using System;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;
using Agiil.BDD.Tasks.Browsing;
using CSF.Screenplay.Web.Builders;
using Agiil.BDD.Pages;
using CSF.Screenplay;
using Agiil.BDD.Actions;
using Agiil.BDD.Tasks.App;
using Agiil.BDD.Personas;
using Agiil.BDD.Tasks.Auth;

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
      Given(joe).WasAbleTo<VisitTheHomePage>();
    }

    [Given(@"Youssef is logged into a fresh installation of the site containing the simple sample project")]
    public void GivenYoussefIsLoggedIntoAFreshlyInstalledSiteWithSimpleSampleData()
    {
      var april = screenplay.GetApril();
      var youssef = screenplay.GetYoussef();

      Given(april).WasAbleTo<InstallTheApplication>();
      Given(april).WasAbleTo<SetupTheSimpleSampleProject>();
      Given(april).WasAbleTo(AddAUserAccount.WithTheUsername(Youssef.Name).AndThePassword(Youssef.Password));
      Given(youssef).WasAbleTo<LogInWithTheirAccount>();
    }

    public WebBrowsingSteps(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));
      this.screenplay = screenplay;
    }
  }
}
