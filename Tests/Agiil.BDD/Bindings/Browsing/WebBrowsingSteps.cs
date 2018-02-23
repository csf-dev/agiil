using System;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;
using Agiil.BDD.Tasks.Browsing;
using Agiil.BDD.Actions;
using Agiil.BDD.Tasks.App;
using Agiil.BDD.Personas;
using Agiil.BDD.Tasks.Auth;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Selenium.Abilities;
using CSF.Screenplay.JsonApis.Abilities;
using Agiil.BDD.Abilities;

namespace Agiil.BDD.Bindings.Browsing
{
  [Binding]
  public class WebBrowsingSteps
  {
    readonly ICast cast;
    readonly Lazy<ITestRunner> testRunner;

    [Given(@"Joe is on on the application home page")]
    public void GivenJoeIsLookingAtTheAppHomePage()
    {
      testRunner.Value.Given("Joe can browse the web");

      var joe = cast.Get<Joe>();
      Given(joe).WasAbleTo<VisitTheHomePage>();
    }

    [Given(@"Youssef is logged into a fresh installation of the site")]
    public void GivenYoussefIsLoggedIntoAFreshlyInstalledSiteWithSimpleSampleData()
    {
      testRunner.Value.Given("Agiil has just been installed");
      testRunner.Value.Given("Youssef has a user account");
      testRunner.Value.Given("Youssef can browse the web");

      var youssef = cast.Get<Youssef>();
      Given(youssef).WasAbleTo<LogInWithTheirAccount>();
    }

    [Given(@"Youssef is logged into a fresh installation of the site containing the simple sample project")]
    public void GivenYoussefIsLoggedIntoAFreshlyInstalledSite()
    {
      testRunner.Value.Given("Agiil has just been installed");
      testRunner.Value.Given("April has set up the simple sample project");
      testRunner.Value.Given("Youssef has a user account");
      testRunner.Value.Given("Youssef can browse the web");

      var youssef = cast.Get<Youssef>();
      Given(youssef).WasAbleTo<LogInWithTheirAccount>();
    }

    public WebBrowsingSteps(ICast cast, Lazy<ITestRunner> testRunner)
    {
      if(cast == null)
        throw new ArgumentNullException(nameof(cast));
      if(testRunner == null)
        throw new ArgumentNullException(nameof(testRunner));

      this.cast = cast;
      this.testRunner = testRunner;
    }
  }
}
